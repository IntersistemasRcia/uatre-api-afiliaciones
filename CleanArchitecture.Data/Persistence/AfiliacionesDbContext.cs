using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Models.APIAudit;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Persistence;

public class AfiliacionesDbContext : DbContext
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ILogger<AfiliacionesDbContext> logger;
    private readonly List<AuditoriaCambioDatos> cambioDatos;

    public AfiliacionesDbContext(DbContextOptions<AfiliacionesDbContext> options,
        IServiceProvider serviceProvider) : base(options)
    {
        httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        logger = serviceProvider.GetRequiredService<ILogger<AfiliacionesDbContext>>();
        cambioDatos = new();
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var userId = httpContextAccessor.HttpContext?.User?.Claims?
            .FirstOrDefault(x => x.Type == "userId")?.Value ?? "Sin Datos";

        foreach (var entry in ChangeTracker.Entries<EntidadAuditable>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = userId;
                    entry.Entity.Guid = Guid.NewGuid();
                    RegistrarAuditoriaDatos(entry, userId, EntityState.Added);

                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = userId;

                    RegistrarAuditoriaDatos(entry, userId, EntityState.Modified);

                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedDate = DateTime.Now;
                    entry.Entity.DeletedBy = userId;

                    RegistrarAuditoriaDatos(entry, userId, EntityState.Modified);
                    break;
            }
        }

        var ret = await base.SaveChangesAsync(cancellationToken);

        if (ret > 0)
        {
            //Envio las auditorias
            await Task.Run(() => GrabarAuditorias(), CancellationToken.None);
        }
                
        return ret;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //excluidas de migrations
        //modelBuilder.Entity<DDJJUatre>().ToTable(nameof(DDJJUatre), t => t.ExcludeFromMigrations());


        //No dejar borrar registros padres con hijos
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    public DbSet<Afiliado>? Afiliados { get; set; }
    public DbSet<Actividad>? Actividades { get; set; }
    public DbSet<Provincia>? Provincias { get; set; }
    public DbSet<Puesto>? Puestos { get; set; }
    public DbSet<Seccional>? Seccionales { get; set; }
    public DbSet<Sexo>? Sexos { get; set; }
    public DbSet<EstadoSolicitud>? EstadosSolicitudes { get; set; }
    public DbSet<Nacionalidad>? Nacionalidades { get; set; }
    public DbSet<SeccionalLocalidad>? SeccionalesLocalidades { get; set; }
    public DbSet<EstadoCivil>? EstadosCiviles { get; set; }
    public DbSet<TipoDocumento>? TiposDocumentos { get; set; }
    public DbSet<RefLocalidad>? RefLocalidades { get; set; }
    public DbSet<SeccionalContacto>? SeccionalContactos { get; set; }
    public DbSet<SeccionalAutoridad>? SeccionalAutoridades { get; set; }
    public DbSet<AfiliadoEstadoSolicitud> AfiliadoEstadosSolicitud { get; set; }
    public DbSet<SeccionalEstado> SeccionalEstados { get; set; }
    public DbSet<InformeSap> InformesSap { get; set; }
    public DbSet<InformeSapDetalle> InformesSapDetalles { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }
    public DbSet<AfiliadoFormularioAfiliacion> AfiliadosFormularioAfiliacion { get; set; }
    public DbSet<NotificacionDetalle> NotificacionesDetalle { get; set; }
    public DbSet<AccesoOsprera> AccesoOsprera { get; set; }
    private void RegistrarAuditoriaDatos(EntityEntry entity, string userId, EntityState entityState)
    {
        cambioDatos.Clear();

        IProperty idProp;
        object idValue;
        idProp = entity.OriginalValues.Properties.FirstOrDefault(x => x.Name == "Guid");

        if (entityState == EntityState.Modified)
        {            
            idValue = entity.OriginalValues[idProp];
        }
        else
        {
            idValue = entity.CurrentValues[idProp];
        }

        var entityType = entity.Entity.GetType();
        var mapping = entity.Context.Model.FindEntityType(entityType);
        var auditoriaCambioDatos = new AuditoriaCambioDatos()
        {
            Usuario = userId,
            Tabla = mapping!.GetTableName()!,
            TablaIdentificador = (Guid)idValue,
            Accion = GetAccion(entity.State.ToString()),
            Cambios = GetChanges(entity, entityState)
        };

        cambioDatos.Add(auditoriaCambioDatos);       
    }

    private static string GetChanges(EntityEntry entity, EntityState entityState)
    {
        var ignoreCols = new List<string>() { "Id", "Guid", "CreatedBy", "LasModifiedBy", "CreatedDate", "LastModifiedDate", "LastModifiedBy" };
        if (entityState == EntityState.Added)
        {
            ignoreCols.AddRange(new List<string>() { "DeletedDate", "DeletedObs" });
        }
        var changes = new StringBuilder();

        if (entityState == EntityState.Modified)
        {
            foreach (var property in entity.OriginalValues.Properties)
            {
                if (!ignoreCols.Contains(property.Name))
                {
                    var originalValue = entity.OriginalValues[property];
                    var currentValue = entity.CurrentValues[property];
                    if (!Equals(originalValue, currentValue))
                    {
                        changes.AppendLine($"{property.Name}: De '{originalValue}' a '{currentValue}'");
                    }
                }                
            }
        }
        else
        {
            foreach (var property in entity.OriginalValues.Properties)
            {
                if (!ignoreCols.Contains(property.Name))
                {
                    var currentValue = entity.CurrentValues[property];                    
                    changes.AppendLine($"{property.Name}: '{currentValue}'");
                }
            };
        }
        return changes.ToString();
    }

    private static string GetAccion(string entityState)
    {
        switch (entityState)
        {
            case "Added":
                return "Agrega";

            case "Modified":
                return "Modifica";
            default:
                return string.Empty;
        }
    }

    private async Task GrabarAuditorias()
    {
        var httpClient = httpClientFactory.CreateClient("APIAuditoria");
        if (string.IsNullOrEmpty(httpClient.BaseAddress?.AbsoluteUri))
        {
            logger.LogError("No se pudo establecer BaseAdress para API Auditoria");
            return;
        }

        foreach (var cambio in cambioDatos)
        {
            try
            {
                var json = JsonSerializer.Serialize(cambio);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/AuditoriasDatos/registrar", content);
                if (!response.IsSuccessStatusCode)
                {
                    logger.LogWarning("Error {err} grabando Auditoria de Datos - json {js} - GUID {g}", response.StatusCode, json.ToString(), cambio.TablaIdentificador);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Exception {ex} intentando grabar AuditoriaDatos", ex.Message);
                //throw;
            }            
        }
    }
}



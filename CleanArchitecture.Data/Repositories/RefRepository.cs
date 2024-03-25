using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Repositories;

public class RefRepository : IRefRepository
{
    private readonly SqlConnection db;
    private readonly IHttpContextAccessor httpContextAccessor;

    public RefRepository(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        db = new SqlConnection(configuration.GetConnectionString("UATRERefConnection"));
        httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    }

    public async Task<RefDelegacion?> GetDelegacionById(int id)
    {
        return await db.QueryFirstOrDefaultAsync<RefDelegacion>("SELECT Id, Nombre FROM RefDelegaciones WHERE Id = @Id", new { Id = id });
    }

    public async Task<RefMotivosBaja?> GetRefMotivoBajaById(int id)
    {
        return await db.QueryFirstOrDefaultAsync<RefMotivosBaja>("SELECT Id, Tipo, Descripcion FROM RefMotivosBaja WHERE Id = @Id", new { Id = id });
    }

    public async Task<Empresa?> GetEmpresaById(int id)
    {
        return await db.QueryFirstOrDefaultAsync<Empresa>("SELECT Id, CUIT, RazonSocial FROM Empresas WHERE Id = @Id", new { Id = id });
    }

    public async Task AgregarDocumentacionEntidad(ICollection<DocumentacionEntidad> documentacionEntidad, string entidadTipo, int entidadId)
    {
        foreach (var item in documentacionEntidad)
        {
            item.EntidadTipo = entidadTipo;
            item.EntidadId = entidadId;
            item.CreatedDate = DateTime.Now;
            item.CreatedBy = httpContextAccessor.HttpContext.User?.Claims?
                .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? "Sin Datos";
        }
        await db.QueryAsync("INSERT INTO DocumentacionEntidades (EntidadTipo, EntidadId, RefTipoDocumentacionId, Archivo, Observaciones, CreatedDate, CreatedBy, NombreArchivo)" +
            "VALUES (@EntidadTipo, @EntidadId, @RefTipoDocumentacionId, @Archivo, @Observaciones, @CreatedDate, @CreatedBy, @NombreArchivo)", documentacionEntidad);
    }

    public async Task AgregarDocumentacionEntidad(DocumentacionEntidad documentacionEntidad, string entidadTipo, int entidadId)
    {
        documentacionEntidad.EntidadTipo = entidadTipo;
        documentacionEntidad.EntidadId = entidadId;
        documentacionEntidad.CreatedDate = DateTime.Now;
        documentacionEntidad.CreatedBy = httpContextAccessor.HttpContext.User?.Claims?
            .FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? "Sin Datos";

        await db.QueryAsync("INSERT INTO DocumentacionEntidades (EntidadTipo, EntidadId, RefTipoDocumentacionId, Archivo, Observaciones, CreatedDate, CreatedBy, NombreArchivo)" +
            "VALUES (@EntidadTipo, @EntidadId, @RefTipoDocumentacionId, @Archivo, @Observaciones, @CreatedDate, @CreatedBy, @NombreArchivo)", documentacionEntidad);
    }

    public async Task<IReadOnlyCollection<DocumentacionEntidad>> GetDocumentacionEntidadById(string tipoEntidad, int entidadId)
    {
        return (await db
            .QueryAsync<DocumentacionEntidad>("SELECT * FROM DocumentacionEntidades WHERE EntidadTipo = @TipoEntidad AND EntidadId = @EntidadId",
            new { TipoEntidad = tipoEntidad, EntidadId = entidadId }))
            .ToList();
    }

    public async Task BorrarDocumentacionEntidad(string tipoEntidad, int idEntidad)
    {
        try
        {
            await db
                .ExecuteAsync("DELETE FROM DocumentacionEntidades WHERE EntidadTipo = @TipoEntidad AND EntidadId = @EntidadId", new { TipoEntidad = tipoEntidad, EntidadId = idEntidad });            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    public async Task BorrarDocumentacionEntidad(int id)
    {
        try
        {
            await db
                .ExecuteAsync("DELETE FROM DocumentacionEntidades WHERE Id = @Id", new { Id = id });            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
}

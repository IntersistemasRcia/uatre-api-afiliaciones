using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AfiliacionesDbContext : DbContext
    {
        public AfiliacionesDbContext(DbContextOptions<AfiliacionesDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntidadAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "test";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "change";
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedDate = DateTime.Now;
                        entry.Entity.DeletedBy = "delete";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
    }
}

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
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
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
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //excluidas de migrations
            modelBuilder.Entity<DDJJUatre>().ToTable(nameof(DDJJUatre), t => t.ExcludeFromMigrations());
        }

        public DbSet<Afiliado>? Afiliados { get; set; }
        public DbSet<Actividad>? Actividades { get; set; }
        public DbSet<Localidad>? Localidades { get; set; }
        public DbSet<Provincia>? Provincias { get; set; }
        public DbSet<Puesto>? Puestos { get; set; }
        public DbSet<Seccional>? Seccionales { get; set; }
        public DbSet<Sexo>? Sexos { get; set; }
        public DbSet<EstadoSolicitud>? EstadosSolicitudes { get; set; }
        public DbSet<Nacionalidad>? Nacionalidades { get; set; }
        public DbSet<SeccionalLocalidad>? SeccionalesLocalidades { get; set; }
        public DbSet<DDJJUatre>? DDJJUatre { get; set; }
        public DbSet<EstadoCivil>? EstadosCiviles { get; set; }
        public DbSet<Empresas>? Empresas { get; set; }
        public DbSet<TipoDocumento>? TiposDocumentos { get; set; }
    }
}

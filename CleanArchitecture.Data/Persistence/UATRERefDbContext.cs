using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CleanArchitecture.Application.Models.APIComunes;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class UATRERefDbContext : DbContext
    {
        public UATRERefDbContext(DbContextOptions<UATRERefDbContext> options) : base(options)
        {

        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //excluidas de migrations
            modelBuilder.Entity<Empresa>().ToTable("Empresas", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<RefDelegacion>().ToTable("RefDelegaciones", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<DocumentacionEntidad>().ToTable("DocumentacionEntidades", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<RefMotivosBaja>().ToTable("RefMotivosBaja", t => t.ExcludeFromMigrations());
        }

        public DbSet<Empresa>? Empresas { get; set; }
        public DbSet<RefDelegacion>? RefDelegaciones { get; set; }
        public DbSet<DocumentacionEntidad>? DocumentacionEntidades { get; set; }
        public DbSet<RefMotivosBaja>? RefMotivosBaja { get; set; }
    }
}

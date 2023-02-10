using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class EmpresaCfg : IEntityTypeConfiguration<Empresas>
    {
        public void Configure(EntityTypeBuilder<Empresas> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder.ToTable("Empresas");
            builder.Property(e => e.LocalidadId).HasColumnName("DomicilioLocalidadesId");

            //Particulares
            builder.ToTable(nameof(Empresas), t => t.ExcludeFromMigrations());
            builder.Ignore(x => x.CreatedBy);
            builder.Ignore(x => x.CreatedDate);
            builder.Ignore(x => x.LastModifiedBy);
            builder.Ignore(x => x.LastModifiedDate);
        }
    }
}

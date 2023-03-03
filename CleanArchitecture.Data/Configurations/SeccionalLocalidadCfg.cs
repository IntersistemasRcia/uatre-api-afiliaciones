
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    internal class SeccionalLocalidadCfg : IEntityTypeConfiguration<SeccionalLocalidad>
    {
        public void Configure(EntityTypeBuilder<SeccionalLocalidad> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            //Relaciones
            builder.HasOne(sl => sl.Seccional).WithMany(s => s.SeccionalLocalidad).HasForeignKey(sl => sl.SeccionalId);
            builder.HasOne(sl => sl.RefLocalidad).WithMany(l => l.SeccionalLocalidad).HasForeignKey(sl => sl.RefLocalidadId);
        }
    }
}


using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

public class ProvinciaCfg : IEntityTypeConfiguration<Provincia>
{
    public void Configure(EntityTypeBuilder<Provincia> builder)
    {
        builder
            .Property(a => a.Id)
            .UseIdentityColumn();

        builder.Property(rv => rv.RowVersion).IsRowVersion();

        builder.HasOne(a => a.Seccional).WithMany().HasForeignKey(a => a.SeccionalIdPorDefecto);
    }
}

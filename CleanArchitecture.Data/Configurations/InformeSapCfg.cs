using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

public class InformeSapCfg : IEntityTypeConfiguration<InformeSap>
{
    public void Configure(EntityTypeBuilder<InformeSap> builder)
    {
        builder
            .Property(a => a.Id)
            .UseIdentityColumn();

        builder.HasMany(x => x.InformeSapDetalles).WithOne().HasForeignKey(x => x.InformeSapId);
    }
}

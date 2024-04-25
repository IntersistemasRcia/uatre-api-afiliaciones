using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations;

public class NotificacionCfg : IEntityTypeConfiguration<Notificacion>
{
    public void Configure(EntityTypeBuilder<Notificacion> builder)
    {
        builder
            .Property(a => a.Id)
            .UseIdentityColumn();

        builder.Property(rv => rv.RowVersion).IsRowVersion();

        builder.HasMany(x => x.NotificacionesDetalle).WithOne().HasForeignKey(x => x.NotificacionesId);
    }
}

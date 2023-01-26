using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class PadronCfg : IEntityTypeConfiguration<Padron>
    {
        public void Configure(EntityTypeBuilder<Padron> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            //Relaciones
            builder.HasOne(a => a.EstadoSolicitud).WithMany().HasForeignKey(a => a.EstadoSolicitudId);
            builder.HasOne(a => a.Seccional).WithMany().HasForeignKey(a => a.SeccionalId);
            builder.HasOne(a => a.Sexo).WithMany().HasForeignKey(a => a.SexoId);
            builder.HasOne(a => a.Actividad).WithMany().HasForeignKey(x => x.ActividadId);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class AfiliadoCfg : IEntityTypeConfiguration<Afiliado>
    {
        public void Configure(EntityTypeBuilder<Afiliado> builder)
        {
            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            //Relaciones
            builder.HasOne(a => a.EstadoSolicitud).WithMany().HasForeignKey(a => a.EstadoSolicitudId);
            builder.HasOne(a => a.Seccional).WithMany().HasForeignKey(a => a.SeccionalId);
            builder.HasOne(a => a.Sexo).WithMany().HasForeignKey(a => a.SexoId);
            builder.HasOne(a => a.Actividad).WithMany().HasForeignKey(x => x.ActividadId);
            builder.HasOne(a => a.Puesto).WithMany().HasForeignKey(x => x.PuestoId);
            builder.HasOne(a => a.RefLocalidad).WithMany().HasForeignKey(x => x.RefLocalidadId);
            //builder.HasOne(a => a.Empresa).WithMany().HasForeignKey(x => x.EmpresaId);
            builder.HasOne(a => a.TipoDocumento).WithMany().HasForeignKey(x => x.TipoDocumentoId);
            builder.HasOne(a => a.Nacionalidad).WithMany().HasForeignKey(x => x.NacionalidadId);
            builder.HasOne(a => a.EstadoCivil).WithMany().HasForeignKey(x => x.EstadoCivilId);

            //Constraints
            builder.HasIndex(u => u.CUIL).IsUnique();
            builder.HasIndex(u => u.CUILValidado);
            builder.HasIndex(u => new { u.NroAfiliado, u.Id }).IsDescending(true, false);
        }
    }
}

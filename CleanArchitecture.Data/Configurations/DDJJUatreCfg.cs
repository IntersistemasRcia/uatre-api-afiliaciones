using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class DDJJUatreCfg : IEntityTypeConfiguration<DDJJUatre>
    {
        public void Configure(EntityTypeBuilder<DDJJUatre> builder)
        {
            //Particulares
            //builder.ToTable(nameof(DDJJUatre), t => t.ExcludeFromMigrations());
            //builder.Ignore(x => x.CreatedBy);
            //builder.Ignore(x => x.CreatedDate);
            //builder.Ignore(x => x.LastModifiedBy);
            //builder.Ignore(x => x.LastModifiedDate);

            //builder.HasOne(a => a.Empresa).WithMany().HasForeignKey(a => a.CUIT).HasPrincipalKey(a => a.CUIT); ;

            // builder.HasOne(sl => sl.Empresa).WithOne(s => s.DDJJUatre).HasForeignKey(sl => sl.CUIT);
            builder.HasIndex(x => new { x.CUIL, x.Periodo });
            builder.HasIndex(x => new { x.CUIT, x.Periodo });
        }
    }
}

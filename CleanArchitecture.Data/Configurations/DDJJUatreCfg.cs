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
            builder.ToTable(nameof(DDJJUatre), t => t.ExcludeFromMigrations());
            builder.Ignore(x => x.CreatedBy);
            builder.Ignore(x => x.CreatedDate);
            builder.Ignore(x => x.LastModifiedBy);
            builder.Ignore(x => x.LastModifiedDate);
        }
    }
}

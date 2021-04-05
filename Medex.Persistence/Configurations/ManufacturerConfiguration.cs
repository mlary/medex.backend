using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class ManufacturerConfiguration : BaseConfiguration<Manufacturer>, IEntityTypeConfiguration<Manufacturer>
    {
        public override void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturers");
            base.Configure(builder);
            builder.Property(_ => _.Name).HasMaxLength(100);
            builder.Property(_ => _.Country).HasMaxLength(100);
            builder.HasMany(_ => _.Products).WithOne(_ => _.Manufacture).HasForeignKey(_ => _.ManufacturerId);
        }
    }
}
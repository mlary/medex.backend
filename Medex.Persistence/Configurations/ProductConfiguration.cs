using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class ProductConfiguration : BaseConfiguration<Product>, IEntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            base.Configure(builder);
            builder.Property(_ => _.Name).HasMaxLength(300);
            builder.Property(_ => _.InterNameId);
            builder.Property(_ => _.GroupNameId);
            builder.Property(_ => _.ManufacturerId);
            builder.HasOne(_ => _.InterName).WithMany(_ => _.Products).HasForeignKey(_ => _.InterNameId);
            builder.HasOne(_ => _.GroupName).WithMany(_ => _.Products).HasForeignKey(_ => _.GroupNameId);
            builder.HasOne(_ => _.Manufacture).WithMany(_ => _.Products).HasForeignKey(_ => _.ManufacturerId);
        }
    }
}
using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class PriceItemConfiguration : BaseConfiguration<PriceItem>, IEntityTypeConfiguration<PriceItem>
    {
        public override void Configure(EntityTypeBuilder<PriceItem> builder)
        {
            builder.ToTable("PriceItems");
            base.Configure(builder);
            builder.Property(_ => _.PriceId);
            builder.Property(_ => _.ProductId);
            builder.Property(_ => _.DistributorId);
            builder.Property(_ => _.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(_ => _.Date);
            builder.Property(_ => _.Cost);
            builder.Property(_ => _.CostInDollar);
            builder.Property(_ => _.CostInEuro);
            builder.Property(_ => _.Margin);
            builder.HasOne(_ => _.Product).WithMany(_ => _.PriceItems).HasForeignKey(_ => _.ProductId);
            builder.HasOne(_ => _.Price).WithMany(_ => _.PriceItems).HasForeignKey(_ => _.PriceId);
            builder.HasOne(_ => _.Distributor).WithMany(_ => _.PriceItems).HasForeignKey(_ => _.DistributorId);
        }
    }
}
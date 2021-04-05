using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class PriceConfiguration : BaseConfiguration<Price>, IEntityTypeConfiguration<Price>
    {
        public override void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");
            base.Configure(builder);
            builder.Property(_ => _.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(_ => _.PublicDate).HasDefaultValueSql("GETDATE()"); ;
            builder.Property(_ => _.DollarRate);
            builder.Property(_ => _.EuroRate);
            builder.Property(_ => _.DocumentId).IsRequired(false);
            builder.Property(_ => _.Status);
            builder.HasOne(_ => _.Document).WithMany()
                .HasForeignKey(_ => _.DocumentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
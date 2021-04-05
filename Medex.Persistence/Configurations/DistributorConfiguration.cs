using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class DistributorConfiguration : BaseConfiguration<Distributor>, IEntityTypeConfiguration<Distributor>
    {
        public override void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.ToTable("Distributors");
            base.Configure(builder);
            builder.Property(_ => _.Name).HasMaxLength(100);
        }
    }
}

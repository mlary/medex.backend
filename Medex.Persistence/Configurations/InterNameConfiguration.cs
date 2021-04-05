using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class InterNameConfiguration : BaseConfiguration<InterName>, IEntityTypeConfiguration<InterName>
    {
        public override void Configure(EntityTypeBuilder<InterName> builder)
        {
            builder.ToTable("InterNames");
            base.Configure(builder);
            builder.Property(_ => _.Name).HasMaxLength(300);
        }
    }
}
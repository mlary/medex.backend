using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class GroupNameConfiguration : BaseConfiguration<GroupName>, IEntityTypeConfiguration<GroupName>
    {
        public override void Configure(EntityTypeBuilder<GroupName> builder)
        {
            builder.ToTable("GroupNames");
            base.Configure(builder);
            builder.Property(_ => _.Name).HasMaxLength(200);
        }
    }
}
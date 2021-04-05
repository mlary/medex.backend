using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class RoleConfiguration : BaseConfiguration<Role>, IEntityTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            base.Configure(builder);
            builder.Property(_ => _.Name).HasMaxLength(100);
            builder.Property(_ => _.Code);
            builder.HasMany(_ => _.UserRoles).WithOne(_ => _.Role).HasForeignKey(_ => _.RoleId);
        }
    }
}
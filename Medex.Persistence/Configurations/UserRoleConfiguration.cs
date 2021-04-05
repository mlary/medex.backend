using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class UserRoleConfiguration : BaseConfiguration<UserRole>, IEntityTypeConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            base.Configure(builder);
            builder.Property(_ => _.UserId);
            builder.Property(_ => _.RoleId);
        }
    }
}
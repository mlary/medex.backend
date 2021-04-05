using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class UserConfiguration : BaseConfiguration<User>, IEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            base.Configure(builder);
            builder.Property(_ => _.FirstName).HasMaxLength(200);
            builder.Property(_ => _.LastName).HasMaxLength(200);
            builder.Property(_ => _.MiddleName).HasMaxLength(200);
            builder.Property(_ => _.Email).HasMaxLength(200);
            builder.Property(_ => _.Password).HasMaxLength(200);
            builder.Property(_ => _.Login).HasMaxLength(200);
            builder.Property(_ => _.Phone).HasMaxLength(200);
            builder.Property(_ => _.CreatedOn).HasColumnType("datetime").HasDefaultValueSql("getdate()");
            builder.Property(_ => _.IsConfirmed);
            builder.Property(_ => _.IsEmailSent);
            builder.Property(_ => _.UserRole);
            builder.HasIndex(_ => _.Email).IsUnique();
            builder.HasIndex(_ => _.Login).IsUnique();
        }
    }
}

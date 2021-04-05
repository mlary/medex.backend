using Medex.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal class DocumentConfiguration : BaseConfiguration<Document>, IEntityTypeConfiguration<Document>
    {
        public override void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            base.Configure(builder);
            builder.Property(_ => _.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(_ => _.Name);
            builder.Property(_ => _.Extension);
        }
    }
}

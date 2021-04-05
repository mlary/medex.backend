using Medex.Domains.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Persistence.Configurations
{
    internal abstract class BaseConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}

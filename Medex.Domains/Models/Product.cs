using Medex.Domains.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medex.Domains.Models
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public long InterNameId { get; set; }
        public long GroupNameId { get; set; }
        public long ManufacturerId { get; set; }
        public List<PriceItem> PriceItems { get; set; }
        public virtual InterName InterName { get; set; }
        public virtual GroupName GroupName { get; set; }
        public virtual Manufacturer Manufacture { get; set; }
    }
}

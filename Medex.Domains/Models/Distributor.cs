using Medex.Domains.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Domains.Models
{
    [Table("Distributors")]
    public class Distributor : BaseEntity
    {
        public string Name { get; set; }
        public List<PriceItem> PriceItems { get; set; }
    }
}

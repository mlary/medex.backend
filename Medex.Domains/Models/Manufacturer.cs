using Medex.Domains.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Domains.Models
{
    [Table("Manufacturers")]
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<Product> Products { get; set; }
    }
}

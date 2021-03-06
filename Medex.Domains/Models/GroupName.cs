using Medex.Domains.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Domains.Models
{
    [Table("GroupNames")]
    public class GroupName : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

}

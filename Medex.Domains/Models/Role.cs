using Medex.Domains.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Domains.Models
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public short Code { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}

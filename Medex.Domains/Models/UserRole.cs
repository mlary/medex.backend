using Medex.Domains.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medex.Domains.Models
{
    [Table("UserRoles")]
    public class UserRole : BaseEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }

        public const string Administrator = "Administrator";
        public const string Client = "Client";
        public const string Guest = "Guest";
        public const string Marketer = "Marketer";


    }
}

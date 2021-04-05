using Medex.Domains.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medex.Domains.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsEmailSent { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte UserRole { get; set; }

    }
}


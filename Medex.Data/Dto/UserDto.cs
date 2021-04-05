using Medex.Data.Dto.Base;
using Medex.Data.Primitives;
using System;

namespace Medex.Data.Dto
{
    public class UserDto : BaseEntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsEmailSent { get; set; }
        public DateTime CreatedOn { get; set; }
        public EnumRoleCodes UserRole { get; set; }
        public string FullName { get; set; }
    }
}

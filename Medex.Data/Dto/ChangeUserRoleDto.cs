using Medex.Data.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medex.Data.Dto
{
    public class ChangeUserRoleDto : BaseEntityDto
    {
        public byte UserRole { get; set; }
    }
}

using Medex.Data.Dto.Base;
using Medex.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medex.Data.Dto
{
    public class ChangePriceStatusDto : BaseEntityDto
    {
        public EnumPriceStatusCode Status { get; set; }
    }
}

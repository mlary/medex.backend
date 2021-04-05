using Medex.Data.Dto.Base.Filtering;
using System;

namespace Medex.Data.Dto.Filtering
{
    public class PriceFilter : BaseFilter
    {
        public FilterDescriptor<DateTime?> PublicDate { get; set; }
    }
}

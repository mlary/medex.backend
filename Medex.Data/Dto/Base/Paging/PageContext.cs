using Medex.Data.Dto.Base.Filtering;
using Medex.Data.Dto.Base.Sorting;
using System.Collections.Generic;

namespace Medex.Data.Dto.Base.Paging
{
    public class PageContext<TFilter> where TFilter : BaseFilter, new()
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public TFilter Filter { get; set; }
        public IEnumerable<SorterDescriptor> SortList { get; set; }

    }
}

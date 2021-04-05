using System.Collections.Generic;

namespace Medex.Data.Dto.Base.Paging
{
    public class PageWrapper<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
    }
}

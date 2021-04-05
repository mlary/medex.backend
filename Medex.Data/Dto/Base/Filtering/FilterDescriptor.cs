using System.Collections.Generic;

namespace Medex.Data.Dto.Base.Filtering
{
    public class FilterDescriptor<T>
    {
        public T Value { get; set; }
        public List<T> Values { get; set; }
        public FilterRange<T> Range { get; set; }

    }
}

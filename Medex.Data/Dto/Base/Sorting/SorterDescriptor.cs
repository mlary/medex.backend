using Medex.Data.Primitives;

namespace Medex.Data.Dto.Base.Sorting
{
    public class SorterDescriptor
    {
        /// <summary>
        /// Field name
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Sort direction, 1-asc, 2-desc
        /// </summary>
        public EnumSortDirection Direction { get; set; }
    }
}

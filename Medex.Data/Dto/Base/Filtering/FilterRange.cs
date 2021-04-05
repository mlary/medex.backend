
namespace Medex.Data.Dto.Base.Filtering
{
    public class FilterRange<T>
    {
        public T Lte { get; set; }
        public T Gte { get; set; }
        public T Gt { get; set; }
        public T Lt { get; set; }
    }
}

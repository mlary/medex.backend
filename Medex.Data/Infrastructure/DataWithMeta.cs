
namespace Medex.Data.Infrastructure
{
    public class DataWithMeta<T>
    {
        public T Data { get; set; }
        public Meta Meta { get; set; }
    }
}

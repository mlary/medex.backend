namespace Medex.Data.Infrastructure
{
    public class NamedObject<T> where T : struct
    {
        public T Id { get; set; }
        public string Name { get; set; }
    }
}

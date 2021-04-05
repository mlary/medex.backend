namespace Medex.Data.Infrastructure
{
    /// <summary>
    /// Мета данные
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Общее кол-во элементов
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// Отфильтрованное кол-во элементов
        /// </summary>
        public long FilteredCount { get; set; }

        /// <summary>
        /// Кол-во возвращаемых элементов
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Кол-во пропускаемых элементов
        /// </summary>
        public int Offset { get; set; }
    }
}

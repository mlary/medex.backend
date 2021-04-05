using Medex.Data.Dto.Base;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class DistributorDto : BaseEntityDto
    {
        /// <summary>
        /// Название поставщика
        /// </summary>
        public string Name { get; set; }
    }
}

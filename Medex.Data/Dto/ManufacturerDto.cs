using Medex.Data.Dto.Base;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Производитель
    /// </summary>
    public class ManufacturerDto : BaseEntityDto
    {
        /// <summary>
        /// Название производителя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }
    }
}

using Medex.Data.Dto.Base;
using Medex.Data.Primitives;
using System;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Прайс лист
    /// </summary>
    public class PriceDto : BaseEntityDto
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime PublicDate { get; set; }
        /// <summary>
        /// Курс доллора
        /// </summary>
        public decimal DollarRate { get; set; }
        /// <summary>
        /// Курс Евро
        /// </summary>
        public decimal EuroRate { get; set; }
        /// <summary>
        /// Статус прайс листа
        /// </summary>
        public EnumPriceStatusCode Status { get; set; }

        public DocumentDto Document { get; set; }

        public long DocumentId { get; set; }
    }
}

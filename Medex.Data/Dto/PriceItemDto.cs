using Medex.Data.Dto.Base;
using System;

namespace Medex.Data.Dto
{
    public class PriceItemDto : BaseEntityDto
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Цена в долларах
        /// </summary>
        public decimal CostInDollar { get; set; }
        /// <summary>
        /// Цена в евро
        /// </summary>
        public decimal CostInEuro { get; set; }
        /// <summary>
        /// Наценка
        /// </summary>
        public decimal Margin { get; set; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime PublicDate { get; set; }

        /// <summary>
        /// Международное название
        /// </summary>
        public string InterName { get; set; }
        /// <summary>
        /// Наименование группы
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Дистрибьютор
        /// </summary>
        public string Distributor { get; set; }
        /// <summary>
        /// Идентификатор прайслиста
        /// </summary>
        public long PriceId { get; set; }

        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public long ProductId { get; set; }
        /// <summary>
        /// Торговое наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор дистрибьютора
        /// </summary>
        public long DistributorId { get; set; }

    }
}

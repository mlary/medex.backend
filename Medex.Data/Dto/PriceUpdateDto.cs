using Medex.Data.Dto.Base;
using Medex.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medex.Data.Dto
{
    public class PriceUpdateDto: BaseEntityDto
    {
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
       
    }
}

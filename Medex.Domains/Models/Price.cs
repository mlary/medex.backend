using Medex.Domains.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medex.Domains.Models
{
    [Table("Prices")]
    public class Price : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime PublicDate { get; set; }
        public decimal DollarRate { get; set; }
        public decimal EuroRate { get; set; }
        public int Status { get; set; }
        public long? DocumentId { get; set; }
        public Document Document { get; set; }
        public List<PriceItem> PriceItems { get; set; }
    }
}

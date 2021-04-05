using Medex.Domains.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Medex.Domains.Models
{
    [Table("PriceItems")]
    public class PriceItem : BaseEntity
    {
        public long PriceId { get; set; }
        public long ProductId { get; set; }
        public long DistributorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal CostInDollar { get; set; }
        public decimal CostInEuro { get; set; }
        public decimal Margin { get; set; }
        public virtual Price Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Distributor Distributor { get; set; }
    }
}

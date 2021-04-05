using Medex.Data.Dto.Base.Filtering;
using System;

namespace Medex.Data.Dto.Filtering
{
    public class PriceItemFilter : BaseFilter
    {
        public FilterDescriptor<string> Product { get; set; }
        public FilterDescriptor<string> Manufacturer { get; set; }
        public FilterDescriptor<string> GroupName { get; set; }
        public FilterDescriptor<string> Distributor { get; set; }
        public FilterDescriptor<string> Country { get; set; }
        public FilterDescriptor<string> InterName { get; set; }
        public FilterDescriptor<long?> ProductId { get; set; }
        public FilterDescriptor<long?> ManufactureId { get; set; }
        public FilterDescriptor<long?> InterNameId { get; set; }
        public FilterDescriptor<long?> GroupNameId { get; set; }
        public FilterDescriptor<long?> DistributorId { get; set; }
        public FilterDescriptor<long?> PriceId { get; set; }
        public FilterDescriptor<decimal?> Cost { get; set; }
        public FilterDescriptor<decimal?> CostInDollar { get; set; }
        public FilterDescriptor<decimal?> CostInEuro { get; set; }
        public FilterDescriptor<DateTime?> PublicDate { get; set; }

    }
}

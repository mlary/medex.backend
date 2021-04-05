using Medex.Data.Dto.Base;

namespace Medex.Data.Dto
{
    public class ProductDto : BaseEntityDto
    {
        public string Name { get; set; }
        public long InterNameId { get; set; }
        public long GroupNameId { get; set; }
        public long ManufacturerId { get; set; }
        public InterNameDto InterName { get; set; }
        public GroupNameDto GroupName { get; set; }
        public ManufacturerDto Manufacture { get; set; }
    }
}

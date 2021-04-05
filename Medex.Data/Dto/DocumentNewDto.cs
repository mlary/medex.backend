using Medex.Data.Dto.Base;
using Microsoft.AspNetCore.Http;

namespace Medex.Data.Dto
{
    public class DocumentNewDto : BaseDto
    {
        public IFormFile Data { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}

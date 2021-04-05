using Medex.Data.Dto.Base;
using Newtonsoft.Json;
using System;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Документ
    /// </summary>
    public class DocumentDto : BaseEntityDto
    {
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}

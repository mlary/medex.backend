using Medex.Domains.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Domains.Models
{
    [Table("Documents")]
    public class Document : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}

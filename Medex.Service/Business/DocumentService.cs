using AutoMapper;
using Medex.Abstractions.Business;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Medex.Service.Common;
using System.IO;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class DocumentService : BaseRestService<Document, DocumentDto, NameFilter>, IDocumentService
    {
        public DocumentService(
            IApplicationDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        {

        }
        public async Task<DocumentDto> CreateAsync(DocumentNewDto document)
        {
            var entity = new Document
            {
                Name = document.Name,
                Extension = document.Extension,
            };

            using (var memoryStream = new MemoryStream())
            {
                await document.Data.CopyToAsync(memoryStream);
                entity.Data = memoryStream.ToArray();
            }

            var createdEntity = _dbContext.Documents.Add(entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<DocumentDto>(createdEntity.Entity);
        }
    }
}

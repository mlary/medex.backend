using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Threading.Tasks;

namespace Medex.Abstractions.Business
{
    public interface IDocumentService : IReadService<Document, DocumentDto, NameFilter>, IDeleteService
    {
        public Task<DocumentDto> CreateAsync(DocumentNewDto data);
    }
}

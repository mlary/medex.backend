using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;

namespace Medex.Abstractions.Business
{
    public interface IInterNameService : IReadService<InterName, InterNameDto, NameFilter>,
        IUpdateService<InterName, InterNameDto>,
        ICreateService<InterName, InterNameDto>,
        IDeleteService
    {
    }
}

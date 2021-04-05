using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;

namespace Medex.Abstractions.Business
{
    public interface IDistributorService : IReadService<Distributor, DistributorDto, NameFilter>,
        ICreateService<Distributor, DistributorDto>,
        IUpdateService<Distributor, DistributorDto>,
        IDeleteService
    {
    }
}

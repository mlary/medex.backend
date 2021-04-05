using AutoMapper;
using Medex.Abstractions.Business;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Medex.Service.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class DistributorService : BaseRestService<Distributor, DistributorDto, NameFilter>, IDistributorService
    {
        public DistributorService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
        public override async Task<IList<DistributorDto>> GetAllAsync(NameFilter filter = null)
        {
            var result = await base.GetAllAsync(filter);
            return result.OrderBy(x => x.Name).ToList();
        }
    }
}

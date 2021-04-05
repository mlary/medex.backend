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
    public class InterNameService : BaseRestService<InterName, InterNameDto, NameFilter>, IInterNameService
    {
        public InterNameService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public override async Task<IList<InterNameDto>> GetAllAsync(NameFilter filter = null)
        {
            var result = (await base.GetAllAsync(filter)).OrderBy(x => x.Name);
            return result.ToList();
        }
    }

}

using AutoMapper;
using Medex.Abstractions.Persistence;

namespace Medex.Service.Common
{
    public abstract class BaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IApplicationDbContext _dbContext;
        protected BaseService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
    }
}

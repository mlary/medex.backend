using AutoMapper;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto.Base;
using Medex.Data.Dto.Base.Filtering;
using Medex.Data.Dto.Base.Paging;
using Medex.Domains.Models.Base;
using Medex.Service.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Service.Common
{
    public abstract class BasePageableService<TEntity, TDto, TFilter> :
        BaseRestService<TEntity, TDto, TFilter>,
        IPaginationService<TDto, TFilter>
        where TEntity : BaseEntity, new()
        where TDto : BaseEntityDto
        where TFilter : BaseFilter, new()
    {
        protected readonly IPageQueryProvider<TEntity, TFilter> _queryProvider;
        protected BasePageableService(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IPageQueryProvider<TEntity, TFilter> queryProvider)
            : base(dbContext, mapper)
        {
            _queryProvider = queryProvider;
        }
        public async Task<PageWrapper<TDto>> GetWithPaging(PageContext<TFilter> context)
        {
            var (list, count) = await _dbContext.Set<TEntity>()
                 .AsQueryable()
                 .GetPageAsync<TEntity, TFilter>(_queryProvider, context);
            return new PageWrapper<TDto>()
            {
                Offset = context.Skip,
                Count = context.Take,
                TotalCount = count,
                Data = _mapper.Map<IEnumerable<TDto>>(list),
            };
        }
    }
}

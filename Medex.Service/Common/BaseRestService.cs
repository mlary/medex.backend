using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto.Base;
using Medex.Data.Dto.Base.Filtering;
using Medex.Domains.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Service.Common
{
    public abstract class BaseRestService<TEntity, TDto, TFilter> : BaseService,
         ICreateService<TEntity, TDto>,
         IUpdateService<TEntity, TDto>,
         IReadService<TEntity, TDto, TFilter>,
         IDeleteService where TEntity : BaseEntity, new() where TDto : BaseEntityDto where TFilter : BaseFilter
    {
        protected BaseRestService(IApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            var createdEntity = _dbContext.Set<TEntity>().Add(entity);

            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<TDto>(createdEntity.Entity);

            return result;
        }

        public virtual async Task<TDto> UpdateAsync(TEntity entity)
        {
            var current = await _dbContext
             .Set<TEntity>()
             .AsNoTracking()
             .FirstOrDefaultAsync(x => x.Id == entity.Id);

            _dbContext.Set<TEntity>().Update(entity);

            await _dbContext.SaveChangesAsync();

            return await GetDtoByIdAsync(entity.Id);
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            return await UpdateAsync(entity);
        }
        public virtual async Task<TDto> GetDtoByIdAsync(long id)
        {
            return await _dbContext.Set<TEntity>()
                .AsQueryable()
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteByIdAsync(long id)
        {
            _dbContext.Remove<TEntity>(new TEntity { Id = id });
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task DeleteByIdsAsync(IEnumerable<long> ids)
        {
            _dbContext.RemoveRange(ids.Select(_ => new TEntity { Id = _ }).ToList());

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IList<TDto>> GetAllAsync(TFilter filter = null)
        {
            return await _dbContext.Set<TEntity>()
                .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync(long id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

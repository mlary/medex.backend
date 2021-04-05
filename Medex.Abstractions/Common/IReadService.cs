using Medex.Data.Dto.Base;
using Medex.Data.Dto.Base.Filtering;
using Medex.Domains.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Abstractions.Common
{
    public interface IReadService<TEntity, TDto, TFilter> where TEntity : BaseEntity where TDto : BaseDto where TFilter : BaseFilter
    {
        Task<IList<TDto>> GetAllAsync(TFilter filter = null);

        Task<TDto> GetDtoByIdAsync(long id);

        Task<TEntity> GetEntityByIdAsync(long id);
    }
}

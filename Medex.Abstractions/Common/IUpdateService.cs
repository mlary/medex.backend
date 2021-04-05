using Medex.Data.Dto.Base;
using Medex.Domains.Models.Base;
using System.Threading.Tasks;

namespace Medex.Abstractions.Common
{
    public interface IUpdateService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        Task<TDto> UpdateAsync(TEntity entity);
        Task<TDto> UpdateAsync(TDto dto);
    }
}

using Medex.Data.Dto.Base;
using Medex.Domains.Models.Base;
using System.Threading.Tasks;

namespace Medex.Abstractions.Common
{
    public interface ICreateService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        Task<TDto> CreateAsync(TDto dto);
    }
}

using Medex.Data.Dto.Base;
using Medex.Data.Dto.Base.Filtering;
using Medex.Data.Dto.Base.Paging;
using System.Threading.Tasks;

namespace Medex.Abstractions.Common
{
    public interface IPaginationService<TEntityDto, TFilter> where TFilter : BaseFilter, new() where TEntityDto : BaseEntityDto
    {
        Task<PageWrapper<TEntityDto>> GetWithPaging(PageContext<TFilter> context);
    }
}
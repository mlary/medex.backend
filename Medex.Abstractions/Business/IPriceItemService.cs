using Medex.Abstractions.Common;
using Medex.Data.Dto;
using Medex.Data.Dto.Base.Paging;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using System.Threading.Tasks;

namespace Medex.Abstractions.Business
{
    public interface IPriceItemService : IReadService<PriceItem, PriceItemDto, PriceItemFilter>,
        ICreateService<PriceItem, PriceItemDto>,
        IUpdateService<PriceItem, PriceItemDto>,
        IDeleteService, IPaginationService<PriceItemDto, PriceItemFilter>
    {
        Task<PageWrapper<PriceItemDto>> GetLastPriceListAsync(PageContext<PriceItemFilter> pageContext);
    }
}

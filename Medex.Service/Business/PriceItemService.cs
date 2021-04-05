using AutoMapper;
using Medex.Abstractions.Business;
using Medex.Abstractions.Common;
using Medex.Abstractions.Persistence;
using Medex.Data.Dto;
using Medex.Data.Dto.Base.Paging;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Medex.Service.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Service.Business
{
    public class PriceItemService : BasePageableService<PriceItem, PriceItemDto, PriceItemFilter>, IPriceItemService
    {
        public PriceItemService(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IPageQueryProvider<PriceItem, PriceItemFilter> queryProvider) : base(dbContext, mapper, queryProvider)
        {

        }

        public async Task<PageWrapper<PriceItemDto>> GetLastPriceListAsync(PageContext<PriceItemFilter> pageContext)
        {
            var priceList = await this._dbContext.Prices.OrderByDescending(x => x.PublicDate).FirstOrDefaultAsync();
            pageContext.Filter.PriceId = new Data.Dto.Base.Filtering.FilterDescriptor<long?>
            {
                Value = priceList.Id
            };
            var result = await this.GetWithPaging(pageContext);
            return result;

        }
    }
}

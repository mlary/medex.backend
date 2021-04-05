using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Data.Dto.Base.Paging;
using Medex.Data.Dto.Filtering;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/priceItems")]
    public class PriceItemController : BaseController
    {
        readonly IPriceItemService _priceItemService;
        public PriceItemController(IPriceItemService priceItemService)
        {
            _priceItemService = priceItemService;
        }

        [HttpPost("page")]
        [ProducesResponseType(typeof(ResponseWrapper<PageWrapper<PriceItemDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PageWrapper<PriceItemDto>>>> Page(PageContext<PriceItemFilter> pageContext) =>
             Ok(await _priceItemService.GetWithPaging(pageContext));

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<PriceItemDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PriceItemDto>>> Create(PriceItemDto data) =>
           Ok(await _priceItemService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<PriceItemDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PriceItemDto>>> Update(PriceItemDto data) =>
          Ok(await _priceItemService.UpdateAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _priceItemService.DeleteByIdAsync(id));

        [HttpPost("pageByLastPriceList")]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<PriceItemDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ICollection<PriceItemDto>>>> PageByLastPriceList(PageContext<PriceItemFilter> pageContext) =>
            Ok(await _priceItemService.GetLastPriceListAsync(pageContext));

    }
}

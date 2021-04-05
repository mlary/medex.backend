using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Data.Dto.Base.Paging;
using Medex.Data.Dto.Filtering;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/prices")]
    public class PriceController : BaseController
    {
        readonly IPriceService _priceService;
        public PriceController(IPriceService PriceService)
        {
            _priceService = PriceService;
        }

        [HttpPost("page")]
        [ProducesResponseType(typeof(ResponseWrapper<PageWrapper<PriceDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PageWrapper<PriceDto>>>> Page(PageContext<PriceFilter> pageContext) =>
             Ok(await _priceService.GetWithPaging(pageContext));

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<PriceDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PriceDto>>> Create(PriceDto data) =>
           Ok(await _priceService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<PriceDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PriceDto>>> Update(PriceUpdateDto data) =>
          Ok(await _priceService.UpdatePriceAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<PriceDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PriceDto>>> Update(ChangePriceStatusDto data) =>
         Ok(await _priceService.ChangePriceStatusAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _priceService.DeleteByIdAsync(id));

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<PriceDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PriceDto>>> GetAll() =>
         Ok(await _priceService.GetAllAsync());

        [HttpGet("last")]
        [ProducesResponseType(typeof(ResponseWrapper<PriceDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PriceDto>> GetLast() =>
        Ok(await _priceService.GetLastPriceAsync());

    }
}

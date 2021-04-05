using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Data.Dto.Base.Paging;
using Medex.Data.Dto.Filtering;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController : BaseController
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("page")]
        [ProducesResponseType(typeof(ResponseWrapper<PageWrapper<ProductDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PageWrapper<ProductDto>>>> Page(PageContext<NameFilter> pageContext) =>
             Ok(await _productService.GetWithPaging(pageContext));

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ProductDto>>> Create(ProductDto data) =>
           Ok(await _productService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<ProductDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ProductDto>>> Update(ProductDto data) =>
          Ok(await _productService.UpdateAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _productService.DeleteByIdAsync(id));

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<ProductDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ICollection<ProductDto>>>> GetAll() =>
            Ok(await _productService.GetAllAsync());

        [HttpGet("names")]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<string>>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ResponseCache(Duration = 600)]
        public async Task<ActionResult<ResponseWrapper<ICollection<string>>>> GetAllNames() =>
            Ok(await _productService.GetProductNameListAsync());

    }
}

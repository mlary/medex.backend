using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/distributors")]
    public class DistributorController : BaseController
    {
        readonly IDistributorService _distributorService;
        public DistributorController(IDistributorService productService)
        {
            _distributorService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<DistributorDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<DistributorDto>>> Create(DistributorDto data) =>
           Ok(await _distributorService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<DistributorDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<DistributorDto>>> Update(DistributorDto data) =>
          Ok(await _distributorService.UpdateAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _distributorService.DeleteByIdAsync(id));

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<DistributorDto>>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ResponseCache(Duration = 600)]
        public async Task<ActionResult<ICollection<DistributorDto>>> GetAll() =>
         Ok(await _distributorService.GetAllAsync());



    }
}

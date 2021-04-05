using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/interNames")]
    public class InterNameController : BaseController
    {
        readonly IInterNameService _interNameService;
        public InterNameController(IInterNameService productService)
        {
            _interNameService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<InterNameDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<InterNameDto>>> Create(InterNameDto data) =>
           Ok(await _interNameService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<InterNameDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<InterNameDto>>> Update(InterNameDto data) =>
          Ok(await _interNameService.UpdateAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _interNameService.DeleteByIdAsync(id));

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<InterNameDto>>), StatusCodes.Status200OK)]
        [ResponseCache(Duration = 600)]
        public async Task<ActionResult<ResponseWrapper<ICollection<InterNameDto>>>> GetAll() =>
         Ok(await _interNameService.GetAllAsync());



    }
}

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
    [Route("api/v{version:apiVersion}/manufacturers")]
    public class ManufacturerController : BaseController
    {
        readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService productService)
        {
            _manufacturerService = productService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<ManufacturerDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ManufacturerDto>>> Create(ManufacturerDto data) =>
           Ok(await _manufacturerService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<ManufacturerDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ManufacturerDto>>> Update(ManufacturerDto data) =>
          Ok(await _manufacturerService.UpdateAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _manufacturerService.DeleteByIdAsync(id));

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<ManufacturerDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<ICollection<ManufacturerDto>>>> GetAll() =>
         Ok(await _manufacturerService.GetAllAsync());

        [HttpGet("countries")]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<string>>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ResponseCache(Duration = 600)]
        public async Task<ActionResult<ResponseWrapper<ICollection<string>>>> GetCountries() =>
        Ok(await _manufacturerService.GetCountriesAsync());
    }
}

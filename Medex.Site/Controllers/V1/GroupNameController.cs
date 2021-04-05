using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/groupNames")]
    public class GroupNameController : BaseController
    {
        readonly IGroupNameService _groupNameService;
        public GroupNameController(IGroupNameService groupNameService)
        {
            _groupNameService = groupNameService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseWrapper<GroupNameDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<GroupNameDto>>> Create(GroupNameDto data) =>
           Ok(await _groupNameService.CreateAsync(data));

        [HttpPut]
        [ProducesResponseType(typeof(ResponseWrapper<GroupNameDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<GroupNameDto>>> Update(GroupNameDto data) =>
          Ok(await _groupNameService.UpdateAsync(data));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(long id) =>
            Ok(await _groupNameService.DeleteByIdAsync(id));

        [HttpGet]
        [ProducesResponseType(typeof(ResponseWrapper<ICollection<GroupNameDto>>), StatusCodes.Status200OK)]
        [ResponseCache(Duration = 600)]
        public async Task<ActionResult<ResponseWrapper<ICollection<GroupNameDto>>>> GetAll() =>
         Ok(await _groupNameService.GetAllAsync());



    }
}

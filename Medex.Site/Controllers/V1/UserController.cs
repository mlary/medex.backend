using Medex.Abstractions.Business;
using Medex.Data.Dto;
using Medex.Data.Dto.Base.Paging;
using Medex.Data.Dto.Filtering;
using Medex.Domains.Models;
using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Medex.Site.Controllers.V1
{
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : BaseController
    {
        readonly IUserService _userService;
        public UserController(IUserService productService)
        {
            _userService = productService;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseWrapper<UserTokenDto>), 200)]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthDto userAuth)
        {
            var userToken = await _userService.Authenticate(userAuth);
            if (userToken == null)
                return GetResponse(HttpStatusCode.NotFound);

            return Ok(userToken);
        }

        [HttpPost("page")]
        [Authorize(Roles = UserRole.Administrator)]
        [ProducesResponseType(typeof(ResponseWrapper<PageWrapper<UserDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PageWrapper<UserDto>>>> Page(PageContext<UserFilter> pageContext) =>
            Ok(await _userService.GetWithPaging(pageContext));



        [HttpPut("changeRole")]
        [Authorize(Roles = UserRole.Administrator)]
        [ProducesResponseType(typeof(ResponseWrapper<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<UserDto>>> ChangeRole(ChangeUserRoleDto data) =>
          Ok(await _userService.ChangeUserRoleAsync(data));


        [ProducesResponseType(typeof(ResponseWrapper<UserDto>), 200)]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userService.GetByLoginAsync(UserIdentity);
            if (user == null)
                return GetResponse(HttpStatusCode.NotFound);

            return Ok(user);
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(ResponseWrapper<UserTokenDto>), 200)]
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserRegistrationDto userRegistration)
        {
            var userToken = await _userService.SignupAsync(userRegistration);
            if (userToken == null)
                return GetResponse(HttpStatusCode.NotFound);

            return Ok(userToken);
        }
    }
}

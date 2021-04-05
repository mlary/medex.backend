using Medex.Site.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Medex.Site.Controllers.V1
{
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Логин текущего пользователя
        /// </summary>
        protected string UserIdentity => HttpContext.User?.Identity?.Name;

        /// <summary>
        /// Сформировать ответ
        /// </summary>
        /// <param name="statusCode">Код ответа</param>
        /// <param name="messageText">Сообщение, поясняющее код ответа</param>
        /// <returns></returns>
        protected ObjectResult GetResponse(HttpStatusCode statusCode, string messageText = null)
        {
            var message = string.IsNullOrWhiteSpace(messageText) ? GetMessage(statusCode) : messageText;
            return StatusCode((int)statusCode, new ResponseWrapper<object>
            {
                Data = null,
                Success = statusCode == HttpStatusCode.OK,
                Error = message
            });
        }

        /// <summary>
        /// Пустой OK ответ
        /// </summary>
        /// <returns></returns>
        protected OkObjectResult OkEmpty()
        {
            return Ok(null);
        }

        /// <inheritdoc />
        /// <summary>
        /// OK с data
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override OkObjectResult Ok(object value)
        {
            return base.Ok(new ResponseWrapper<object>
            {
                Data = value,
                Success = true,
                Error = null
            });
        }


        private string GetMessage(HttpStatusCode code)
        {
            switch (code)
            {
                case HttpStatusCode.NotFound:
                    return "Entity with specified Id not found";
                case HttpStatusCode.Forbidden:
                    return "Insufficient rights";
                case HttpStatusCode.BadRequest:
                    return "Specified model is invalid";
                case HttpStatusCode.Unauthorized:
                    return "Not found current user in Database.";
                default:
                    return "";
            }
        }
    }
}


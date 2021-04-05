using Medex.Data.Dto.Base;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Токен пользователя для аутентификации
    /// </summary>
    public class UserTokenDto : BaseDto

    {
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }
    }
}

using Medex.Data.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Аутентификационные данные пользователя
    /// </summary>
    public class UserAuthDto : BaseDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}

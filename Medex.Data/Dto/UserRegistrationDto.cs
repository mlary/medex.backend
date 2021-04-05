using Medex.Data.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Аутентификационные данные пользователя
    /// </summary>
    public class UserRegistrationDto : BaseDto
    {

        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [Required]
        public string MiddleName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Required(ErrorMessage = "Укажите телефон")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Телефон введен не верно")]
        public string Phone { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [MinLength(6, ErrorMessage = "Пароль очень короткий")]
        [MaxLength(200, ErrorMessage = "Пароль очень длинный")]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Укажите email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email введен не правильно")]
        public string Email { get; set; }
    }
}

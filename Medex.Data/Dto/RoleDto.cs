using Medex.Data.Dto.Base;

namespace Medex.Data.Dto
{
    /// <summary>
    /// Роли пользователя
    /// </summary>
    public class RoleDto : BaseEntityDto
    {
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public short Code { get; set; }
    }
}

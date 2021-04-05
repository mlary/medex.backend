using Medex.Data.Dto.Base;


namespace Medex.Data.Dto
{
    /// <summary>
    /// Группа
    /// </summary>
    public class GroupNameDto : BaseEntityDto
    {
        /// <summary>
        /// Название группы
        /// </summary>
        public string Name { get; set; }
    }
}

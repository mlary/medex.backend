using System.ComponentModel.DataAnnotations;

namespace Medex.Data.Primitives
{
    /// <summary>
    /// Перечень статусов прайс листа
    /// </summary>
    public enum EnumPriceStatusCode : byte
    {
        /// <summary>
        /// Новый
        /// </summary>
        [Display(Name = "Новый")]
        New = 0,
        /// <summary>
        /// На обработке
        /// </summary>
        [Display(Name = "На обработке")]
        Processing = 1,
        /// <summary>
        /// Активный
        /// </summary>
        [Display(Name = "Активный")]
        Active = 2,
        /// <summary>
        /// Пустой
        /// </summary>
        [Display(Name = "Пустой")]
        Empty = 3,
        /// <summary>
        /// Ошибка обработки
        /// </summary>
        [Display(Name = "Ошибка обработки")]
        ErrorProcessing = 4,
        /// <summary>
        /// Не активный
        /// </summary>
        [Display(Name = "Не активный")]
        Disabled = 5
    }
}

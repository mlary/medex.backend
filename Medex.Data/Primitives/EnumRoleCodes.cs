using System.ComponentModel.DataAnnotations;
namespace Medex.Data.Primitives
{
    public enum EnumRoleCodes
    {
        [Display(Name = "Администратор")]
        Administrator = 1,
        [Display(Name = "Гость")]
        Guest = 2,
        [Display(Name = "Клиент")]
        Client = 3,
        [Display(Name = "Маркетолог")]
        Marketer = 4
    }
}

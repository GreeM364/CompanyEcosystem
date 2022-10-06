using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Вкажіть електрону адресу")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Вкажіть пароль")]
        [MinLength(6, ErrorMessage = "Пароль повинен мати довжину не менше 8 символів")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "Паролі не збігаються")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Вкажіть посаду")]
        public string Position { get; set; }
    }
}

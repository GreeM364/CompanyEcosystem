using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class AuthenticateViewModel
    {
        [Required(ErrorMessage = "Вкажіть електрону адресу")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть пароль")]
        public string Password { get; set; }
    }
}

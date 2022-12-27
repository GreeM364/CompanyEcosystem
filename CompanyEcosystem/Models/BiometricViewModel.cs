using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class BiometricViewModel
    {
        [Required(ErrorMessage = "Вкажіть електрону адресу")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Вкажіть відбиток пальця")]
        public string FingerprintData { get; set; }

        [Required(ErrorMessage = "Вкажіть сітківку глаза")]
        public string RetinaScanData { get; set; }
    }
}

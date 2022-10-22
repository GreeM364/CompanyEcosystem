using System.ComponentModel.DataAnnotations;
using CompanyEcosystem.Enum;

namespace CompanyEcosystem.PL.Models
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Enter an email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a password")]
        [MinLength(6, ErrorMessage = "The password must be at least 6 characters long")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Specify the position")]
        public Position Position { get; set; }

        [Required(ErrorMessage = "Enter a location")]
        public int LocationId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Enter an email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a password")]
        [MinLength(6, ErrorMessage = "The password must be at least 8 characters long")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Specify the position")]
        public string Position { get; set; }

        public int LocationId { get; set; }
    }
}

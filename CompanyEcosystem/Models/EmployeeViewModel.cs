using CompanyEcosystem.Enum;

namespace CompanyEcosystem.PL.Models
{
    public class EmployeeViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public string Token { get; set; }
    }
}

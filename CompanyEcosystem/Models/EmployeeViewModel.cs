using CompanyEcosystem.Enum;

namespace CompanyEcosystem.PL.Models
{
    public class EmployeeViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public Role Role { get; set; }
        public Position Position { get; set; }
        public string Token { get; set; }
    }
}

using CompanyEcosystem.Enum;

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Position Position { get; set; }
        public string Token { get; set; }
        public string? FingerprintData { get; set; }
        public string? RetinaScanData { get; set; }

        public int? LocationId { get; set; }
    }
}

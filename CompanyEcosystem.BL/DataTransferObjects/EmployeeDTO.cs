namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public string Token { get; set; }

        public int LocationId { get; set; }
    }
}

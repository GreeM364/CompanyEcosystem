using CompanyEcosystem.Enum;

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class QuestionnaireDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Photo { get; set; }
        public string Path { get; set; }
        public string AboutMyself { get; set; }
        public string LinkToLinkedIn { get; set; }

        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public Position Position { get; set; }
    }
}

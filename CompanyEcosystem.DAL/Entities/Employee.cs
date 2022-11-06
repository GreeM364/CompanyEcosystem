using CompanyEcosystem.Enum;

namespace CompanyEcosystem.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Place { get; set; }
        public Role Role { get; set; }
        public Position Position { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public Questionnaire? Questionnaires { get; set; }
    }
}

using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Chief { get; set; }
        public string? Path { get; set; }
        public byte[] Photo { get; set; }
        public string ChiefEmail { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingEnd { get; set; }

        public List<EmployeeDto> Employees { get; set; }
        public List<ThingDto> Things { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}

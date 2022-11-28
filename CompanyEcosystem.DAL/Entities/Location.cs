namespace CompanyEcosystem.DAL.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Chief { get; set; }
        public string? Photo { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingEnd { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Thing> Things { get; set; }
        public List<Post> Posts { get; set; }
    }
}

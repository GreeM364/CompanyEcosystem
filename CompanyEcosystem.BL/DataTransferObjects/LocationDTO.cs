namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Chief { get; set; }
        public string ChiefEmail { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingEnd { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}

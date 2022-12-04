namespace CompanyEcosystem.PL.Models
{
    public class LocationViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string ChiefEmail { get; set; }
        public string Path { get; set; }
        public byte[] Photo { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingEnd { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }
    }
}

namespace CompanyEcosystem.PL.Models
{
    public class LocationViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string ChiefEmail { get; set; }
        public DateTime WorkingStart { get; set; }
        public DateTime WorkingEnd { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}

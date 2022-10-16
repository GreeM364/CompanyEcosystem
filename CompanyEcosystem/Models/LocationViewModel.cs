using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class LocationViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter a chief")]
        public int Chief { get; set; }

        [Required(ErrorMessage = "Enter the start time")]
        public DateTime WorkingStart { get; set; }

        [Required(ErrorMessage = "Enter the end time")]
        public DateTime WorkingEnd { get; set; }

        public string Test => AuthenticateResponse.FirstOrDefault(e => (e.Id == Chief)).Email;

        public IEnumerable<EmployeeViewModel>? AuthenticateResponse { get; set; }
    }
}

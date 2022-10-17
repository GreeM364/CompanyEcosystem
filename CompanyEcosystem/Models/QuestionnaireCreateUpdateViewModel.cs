using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class QuestionnaireCreateUpdateViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Enter your name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your patronymic")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        public string LastName { get; set; }

        [Phone]
        [Required(ErrorMessage = "Enter your phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter your birthday")]
        public DateTime Birthday { get; set; }

        //[Required(ErrorMessage = "Upload your photo")]
        //public string Photo { get; set; }

        [Required(ErrorMessage = "Enter information about yourself")]
        public string AboutMyself { get; set; }

        [Required(ErrorMessage = "Enter link to LinkedIn")]
        public string LinkToLinkedIn { get; set; }


        public int EmployeeId { get; set; }
    }
}

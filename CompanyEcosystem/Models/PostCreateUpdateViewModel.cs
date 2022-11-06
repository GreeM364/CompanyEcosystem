using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class PostCreateUpdateViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter a body")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Enter a location")]
        public int LocationId { get; set; }
    }
}

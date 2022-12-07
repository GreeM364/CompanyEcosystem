using System.ComponentModel.DataAnnotations;

namespace CompanyEcosystem.PL.Models
{
    public class ThingUpdateViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a instruction")]
        public string Instruction { get; set; }

        [Required(ErrorMessage = "Enter a characteristic")]
        public string Characteristic { get; set; }

        
        public IFormFileCollection? Images { get; set; }

        public string[]? Paths { get; set; }

        public int LocationId { get; set; }
    }
}

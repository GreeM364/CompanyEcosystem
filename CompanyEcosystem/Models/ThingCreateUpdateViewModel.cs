using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CompanyEcosystem.PL.Models
{
    public class ThingCreateUpdateViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a instruction")]
        public string Instruction { get; set; }

        [Required(ErrorMessage = "Enter a characteristic")]
        public string Characteristic { get; set; }

        public IFormFileCollection? Images { get; set; }

        public int LocationId { get; set; }
    }
}

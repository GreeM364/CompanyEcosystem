using System.Collections.Generic;

namespace CompanyEcosystem.PL.Models
{
    public class ThingViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Characteristic { get; set; }
        public int LocationId { get; set; }

        public IEnumerable<PhotoThingViewModel> Photos { get; set; }
    }
}

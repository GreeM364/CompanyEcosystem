namespace CompanyEcosystem.PL.Models
{
    public class CreateThingViewModel
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Characteristic { get; set; }

        public IFormFileCollection? Images { get; set; }
    }
}

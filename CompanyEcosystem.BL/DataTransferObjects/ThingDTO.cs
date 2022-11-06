using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class ThingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Characteristic { get; set; }

        public int LocationId { get; set; }
        public List<PhotoThingDto> Photos { get; set; }
    }
}

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class ThingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Characteristic { get; set; }

        public int LocationId { get; set; }
        public IEnumerable<PhotoThingDto> PhotoThing { get; set; }
    }
}

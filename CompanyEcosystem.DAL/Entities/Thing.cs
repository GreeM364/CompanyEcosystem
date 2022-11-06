namespace CompanyEcosystem.DAL.Entities
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public string Characteristic { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public IEnumerable<PhotoThing> Photos { get; set; }
    }
}

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class PhotoThingDto
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int ThingId { get; set; }
        public ThingDto Thing { get; set; }
    }
}

namespace CompanyEcosystem.BL.DataTransferObjects
{
    public class PhotoThingDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public byte[] Photo { get; set; }

        public int ThingId { get; set; }
    }
}

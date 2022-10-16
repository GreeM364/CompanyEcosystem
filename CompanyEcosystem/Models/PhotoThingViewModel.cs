
namespace CompanyEcosystem.PL.Models
{
    public class PhotoThingViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int ThingId { get; set; }
        public ThingViewModel Thing { get; set; }
    }
}

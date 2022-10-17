
namespace CompanyEcosystem.PL.Models
{
    public class PhotoThingViewModel : BaseViewModel
    {
        public string Path { get; set; }

        public int ThingId { get; set; }
        public ThingViewModel Thing { get; set; }
    }
}

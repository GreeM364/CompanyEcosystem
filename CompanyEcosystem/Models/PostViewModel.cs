namespace CompanyEcosystem.PL.Models
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public long Mark { get; set; }
        public DateTime Create { get; set; }
    }
}

namespace CompanyEcosystem.DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public long Mark { get; set; }
        public DateTime Create { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; }
    }
}

namespace CMSStyleApi.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string UserId { get; set; }

        public ICollection<Page> Pages { get; set; } = new List<Page>();
    }
}

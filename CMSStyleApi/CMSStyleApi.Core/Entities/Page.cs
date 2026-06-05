namespace CMSStyleApi.Core.Entities
{
    public class Page
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PageTemplateId { get; set; }

        public PageTemplate PageTemplate { get; set; }

    }
}

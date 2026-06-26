namespace CMSStyleApi.Core.Entities
{
    public class Page
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProjectId{ get; set; }
        public string Content { get; set; } = string.Empty;
        public string HeaderContent { get; set; } = string.Empty;
        public string MainContent { get; set; } = string.Empty;
        public string FooterContent { get; set; } = string.Empty;
        public string HeaderStyleJson { get; set; } = "{}";
        public string MainStyleJson { get; set; } = "{}";
        public string FooterStyleJson { get; set; } = "{}";
        public string NavStyleJson { get; set; } = "{}";
        public bool IsPublished { get; set; } = false;
        public bool IsInNavMenu { get; set; } = false;
        public int? NavOrder { get; set; } = null;
        public Project Project { get; set; }
    }
}

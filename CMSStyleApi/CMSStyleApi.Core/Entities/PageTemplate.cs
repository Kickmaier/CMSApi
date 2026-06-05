namespace CMSStyleApi.Core.Entities
{
    public class PageTemplate
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string BackgroundColor { get; set; } = "#ffffff";
        public string FontStyle { get; set; } = "sans-serif";
        public string HeaderColor { get; set; } = "#333333";
        public string FooterColor { get; set; } = "#111111";

        public bool ShowSidebarLeft { get; set; } = true;
        public bool ShowSidebarRight { get; set; } = true;
        public bool ShowFooter { get; set; } = true;

        public Project Project { get; set; }
        public ICollection<Page> Pages { get; set; } = new List<Page>();
    }
}

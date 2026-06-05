using CMSStyleApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CMSStyleApi.Application.DTOs
{
    public class PageTemplateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public string? BackgroundColor { get; set; } = "#ffffff";
        public string? FontStyle { get; set; } = "sans-serif";
        public string? HeaderColor { get; set; } = "#333333";
        public string FooterColor { get; set; } = "#111111";

        public bool ShowSidebarLeft { get; set; } = true;
        public bool ShowSidebarRight { get; set; } = true;
        public bool ShowFooter { get; set; } = true;

        public static Expression<Func<PageTemplate, PageTemplateDto>> FromEntity => template => new PageTemplateDto
        {
            Id = template.Id,
            Name = template.Name,
            ProjectId = template.ProjectId,
            BackgroundColor = template.BackgroundColor,
            FontStyle = template.FontStyle,
            HeaderColor = template.HeaderColor,
            FooterColor = template.FooterColor,
            ShowSidebarLeft = template.ShowSidebarLeft,
            ShowSidebarRight = template.ShowSidebarRight,
            ShowFooter = template.ShowFooter
        };
    }
}

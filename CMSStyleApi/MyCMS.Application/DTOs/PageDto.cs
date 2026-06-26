using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using CMSStyleApi.Core.Entities;

namespace CMSStyleApi.Application.DTOs
{
    public class PageDto
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int ProjectId { get; set; }
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

        public static Expression<Func<Page, PageDto>> FromEntity => page => new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            ProjectId = page.ProjectId,
            Content = page.Content,
            HeaderContent = page.HeaderContent,
            MainContent = page.MainContent,
            FooterContent = page.FooterContent,
            HeaderStyleJson = page.HeaderStyleJson,
            MainStyleJson = page.MainStyleJson,
            FooterStyleJson = page.FooterStyleJson,
            NavStyleJson = page.NavStyleJson,
            IsPublished = page.IsPublished,
            IsInNavMenu = page.IsInNavMenu,
            NavOrder = page.NavOrder
        };
    }
        
}

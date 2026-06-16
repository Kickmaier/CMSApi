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
        public string? Content { get; set; }
        public int PageTemplateId { get; set; }
        public bool IsPublished { get; set; } = false;
        public bool IsInNavMenu { get; set; } = false;
        public int? NavOrdet { get; set; } = null;

        public static Expression<Func<Page, PageDto>> FromEntity => page => new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Content = page.Content,
            PageTemplateId = page.PageTemplateId,
            IsPublished = page.IsPublished,
            IsInNavMenu = page.IsInNavMenu,
            NavOrdet = page.NavOrdet
        };
    }
        
}

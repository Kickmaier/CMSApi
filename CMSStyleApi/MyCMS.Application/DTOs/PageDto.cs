using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using CMSStyleApi.Core.Entities;

namespace CMSStyleApi.Application.DTOs
{
    public class PageDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public int PageTemplateId { get; set; }

        public static Expression<Func<Page, PageDto>> FromEntity => page => new PageDto
        {
            Id = page.Id,
            Title = page.Title,
            Content = page.Content,
            PageTemplateId = page.PageTemplateId
        };
    }
        
}

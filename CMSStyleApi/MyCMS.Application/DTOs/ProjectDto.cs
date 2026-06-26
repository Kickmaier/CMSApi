using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using CMSStyleApi.Core.Entities;


namespace CMSStyleApi.Application.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public static Expression<Func<Project, ProjectDto>> FromEntity => project => new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
        };

    }
}

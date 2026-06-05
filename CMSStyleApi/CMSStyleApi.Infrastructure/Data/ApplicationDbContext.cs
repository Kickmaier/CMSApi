using CMSStyleApi.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CMSStyleApi.Infrastructure.Data
    
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PageTemplate>()
                   .HasOne(pt => pt.Project)
                   .WithMany(p => p.PageTemplates)
                   .HasForeignKey(pt => pt.ProjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Page>()
                   .HasOne(p => p.PageTemplate)
                   .WithMany(pt => pt.Pages)
                   .HasForeignKey(p => p.PageTemplateId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Page>()
                   .HasIndex(p => p.UserId);
        }
            public DbSet<PageTemplate> PageTemplates { get; set; }
            public DbSet<Page> Pages { get; set; }
            public DbSet<Project> Projects {  get; set; }
    }
}


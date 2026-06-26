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

            builder.Entity<Page>()
                    .HasOne(p => p.Project)
                    .WithMany(pr => pr.Pages)
                    .HasForeignKey(p => p.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
            
            public DbSet<Page> Pages { get; set; }
            public DbSet<Project> Projects {  get; set; }
    }
}


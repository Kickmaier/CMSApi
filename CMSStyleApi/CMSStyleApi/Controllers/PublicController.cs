using CMSStyleApi.Application.DTOs;
using CMSStyleApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSStyleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("project/{projectName}/pages")]
        public async Task<IActionResult> GetPublicProjectPages(string projectName)
        {
            var toLower = projectName.ToLower();

            var existingProject = await _context.Projects
                .AnyAsync(p => p.Name.ToLower() == toLower);

            if(!existingProject)
            {
                return NotFound($"{projectName} existerar inte");
            }
            else
            {
                var publishedPages = await _context.Pages
                    .Where(p => p.Project.Name.ToLower() == toLower
                    && p.IsPublished == true
                    && p.NavOrder != null)
                    .OrderBy(p => p.NavOrder)
                    .Select(p => new PageDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        NavOrder = p.NavOrder
                    })
                    .ToListAsync();
                return Ok(publishedPages);
            }
        }
        [HttpGet("project/{projectName}/pages/{Id}")]
        public async Task<IActionResult> GetPublicPage(string projectName, int id)
        {
            var toLower = projectName.ToLower();
            var page = await _context.Pages
                .FirstOrDefaultAsync(p => p.Project.Name.ToLower() == toLower
                && p.Id == id
                && p.IsPublished == true);

            if (page == null)
            {
                return NotFound();
            }
            return Ok(page);
        }
    }
}

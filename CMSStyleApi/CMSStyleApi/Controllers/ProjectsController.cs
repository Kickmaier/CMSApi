using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMSStyleApi.Infrastructure.Data;
using CMSStyleApi.Application.DTOs;
using CMSStyleApi.Core.Entities;
namespace CMSStyleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjects([FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            return await _context.Projects
                .Where(x => x.UserId == userId)
                .Select(ProjectDto.FromEntity)
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id, [FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var project = await _context.Projects
                 .Where(p => p.Id == id && p.UserId == userId)
                 .Select(ProjectDto.FromEntity)
                 .FirstOrDefaultAsync();

            if (project == null) { return NotFound("Projektet existerar inte eller så saknar du behörighet"); }

            return Ok(project);
        }
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(ProjectDto createdDto, [FromQuery] string userId)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var project = new Project
            {
                Name = createdDto.Name,
                Description = createdDto.Description,
                UserId = userId
            };
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            createdDto.Id = project.Id;

            return CreatedAtAction(nameof(GetProject), new { id = project.Id, userId = userId }, createdDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, ProjectDto updateDto, [FromQuery] string userId)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != updateDto.Id) { return BadRequest("Id matchar inte"); }

            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (project == null) { return NotFound("Projectet finns inte eller behörighet saknas"); }

            project.Name = updateDto.Name;
            project.Description = updateDto.Description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateDto);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id, [FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (project == null) { return NotFound("Projectet finns inte eller så saknar du behörighet."); }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }    
}

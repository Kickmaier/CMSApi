using CMSStyleApi.Application.DTOs;
using CMSStyleApi.Core.Entities;
using CMSStyleApi.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSStyleApi.Controllers
{
    [ApiController]
    [Route("api/pagetemplates")]
    public class PageTemplatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PageTemplatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageTemplateDto>>> GetPageTemplates([FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            return await _context.PageTemplates
                .Where(x => x.Project.UserId == userId)
                .Select(PageTemplateDto.FromEntity)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<PageTemplateDto>> CreatePageTemplate(PageTemplateDto createDto, [FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var projectExists = await _context.Projects
                .AnyAsync(p => p.Id == createDto.ProjectId && p.UserId == userId);

            if (!projectExists)
            {
                return Forbid("Inget relevant projeke existerar eller så saknar du behörighet");
            }

            var template = new PageTemplate
            {
                Name = createDto.Name,
                ProjectId = createDto.ProjectId,
                BackgroundColor = createDto.BackgroundColor,
                FontStyle = createDto.FontStyle,
                HeaderColor = createDto.HeaderColor,
                FooterColor = createDto.FooterColor,
                ShowSidebarLeft = createDto.ShowSidebarLeft,
                ShowSidebarRight = createDto.ShowSidebarRight,
                ShowFooter = createDto.ShowFooter,
            };

            _context.PageTemplates.Add(template);
            await _context.SaveChangesAsync();

            createDto.Id = template.Id;

            return CreatedAtAction(nameof(GetPageTemplate), new { id = template.Id, userId = userId }, createDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PageTemplateDto>> GetPageTemplate(int id, [FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var templateDto = await _context.PageTemplates
                 .Where(p => p.Id == id && p.Project.UserId == userId)
                 .Select(PageTemplateDto.FromEntity)
                 .FirstOrDefaultAsync();


            if (templateDto == null) { return NotFound("Mallen finns inte eller så saknar du behörighet"); }

            return Ok(templateDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePageTemplate(int id, PageTemplateDto updateDto, [FromQuery] string userId)
        {
            if (id != updateDto.Id) { return BadRequest("Id matchar inte"); }

            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var template = await _context.PageTemplates
                .Include (p => p.Project)
                .FirstOrDefaultAsync(p => p.Id == id && p.Project.UserId == userId);

            if (template == null) { return NotFound("Mallen finns inte eller behörighet saknas"); }

            template.Name = updateDto.Name;
            template.BackgroundColor = updateDto.BackgroundColor;
            template.FontStyle = updateDto.FontStyle;
            template.HeaderColor = updateDto.HeaderColor;
            template.FooterColor = updateDto.FooterColor;
            template.ShowSidebarLeft = updateDto.ShowSidebarLeft;
            template.ShowSidebarRight = updateDto.ShowSidebarRight;
            template.ShowFooter = updateDto.ShowFooter;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PageTemplates.Any(e => e.Id == id))
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
        public async Task<ActionResult> DeletePageTemplate(int id, [FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var template = await _context.PageTemplates
                .FirstOrDefaultAsync(p => p.Id == id && p.Project.UserId == userId);

            if (template == null) { return NotFound("Mallen finns inte eller så saknar du behörighet."); }

            _context.PageTemplates.Remove(template);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}


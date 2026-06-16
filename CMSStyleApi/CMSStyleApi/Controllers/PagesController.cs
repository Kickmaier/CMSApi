using CMSStyleApi.Application.DTOs;
using CMSStyleApi.Core.Entities;
using CMSStyleApi.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace CMSStyleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PagesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageDto>>> GetAllPages([FromQuery(Name ="userId")] string userId )
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }
                
                return await _context.Pages
                    .Where(x => x.UserId == userId)
                    .Select(PageDto.FromEntity)
                    .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<PageDto>> CreatePage(PageDto createdDto, [FromQuery] string userId)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var projectExists = await _context.Projects
            .AnyAsync(p => p.Id == createdDto.ProjectId && p.UserId == userId);

            if (!projectExists)
            {
                return NotFound("Du måste skapa ett projekt först");
            }

            var page = new Page
            {
                UserId = userId,
                Title = createdDto.Title,
                Content = createdDto.Content,
                ProjectId = createdDto.ProjectId,
                IsPublished=createdDto.IsPublished,
                IsInNavMenu = createdDto.IsInNavMenu,
                NavOrdet = createdDto.NavOrdet
            };
            _context.Pages .Add(page);
            await _context.SaveChangesAsync();

            createdDto.Id = page.Id;

            return CreatedAtAction(nameof(GetPage), new { id = page.Id, userId = userId }, createdDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PageDto>> GetPage(int id, [FromQuery] string userId)
        {
            if(string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }

            var page = await _context.Pages
                 .Where(p => p.Id == id && p.UserId == userId )
                 .Select(PageDto.FromEntity)
                 .FirstOrDefaultAsync();

            if (page == null)
            {
                return NotFound("Sidan kunde inte hämtas");
            }

            return Ok(page);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePage(int id, PageDto updateDto, [FromQuery] string userId)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != updateDto.Id) { return BadRequest("Id matchar inte"); }

            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }
            
            var page = await _context.Pages
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (page == null) { return NotFound("Sidan finns inte eller behörighet saknas"); }

            page.Title = updateDto.Title;
            page.Content = updateDto.Content;
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_context.Pages.Any(e => e.Id == id))
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
        public async Task<ActionResult> DeletePage(int id, [FromQuery] string userId)
        {
            if (string.IsNullOrEmpty(userId)) { return BadRequest("UserId saknas"); }
            
            var page = await _context.Pages
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
            
            if (page == null) { return NotFound("Sidan finns inte eller så saknar du behörighet."); }

            _context.Pages.Remove(page);
            await _context.SaveChangesAsync();

            return NoContent();
            
        }
    }
}

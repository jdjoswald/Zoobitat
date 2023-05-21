using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabitatController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TipoHabitatController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<TipoHabitat>>> GetTiposHabitat()
        {
            return await _context.TiposHabitat.ToListAsync();
        }

        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<TipoHabitat>> GetTipoHabitat(int id)
        {
            var tipoHabitat = await _context.TiposHabitat.FindAsync(id);

            if (tipoHabitat == null)
            {
                return NotFound();
            }

            return tipoHabitat;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<TipoHabitat>> CreateTipoHabitat(TipoHabitat tipoHabitat)
        {
            _context.TiposHabitat.Add(tipoHabitat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoHabitat", new { id = tipoHabitat.IdTipoHabitat }, tipoHabitat);
        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> UpdateTipoHabitat(int id, TipoHabitat tipoHabitat)
        {
            if (id != tipoHabitat.IdTipoHabitat)
            {
                return BadRequest();
            }

            _context.Entry(tipoHabitat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoHabitatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> DeleteTipoHabitat(int id)
        {
            var tipoHabitat = await _context.TiposHabitat.FindAsync(id);
            if (tipoHabitat == null)
            {
                return NotFound();
            }

            _context.TiposHabitat.Remove(tipoHabitat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoHabitatExists(int id)
        {
            return _context.TiposHabitat.Any(t => t.IdTipoHabitat == id);
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitatController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public HabitatController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<Habitat>>> GetHabitats()
        {
            var habitats = await _context.Habitats.Include(h => h.TipoHabitat).ToListAsync();

            return habitats;
        }


        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Habitat>> GetHabitat(int id)
        {
            var habitat = await _context.Habitats.Include(h => h.TipoHabitat).FirstOrDefaultAsync(h => h.IdHabitat == id);

            if (habitat == null)
            {
                return NotFound();
            }

            return habitat;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Habitat>> CreateHabitat(Habitat habitat)
        {
           // var tipoHabitat = await _context.TiposHabitat.FindAsync(habitat.IdTipoHabitat);

            var tipoHabitat = await _context.TiposHabitat.FindAsync(habitat.IdTipoHabitat);
            //var rol = _context.Roles.FirstOrDefault(r => r.IdRol == usuario.IdRol);

            if (tipoHabitat == null)
            {
                return NotFound("El tipo de hábitat especificado no existe.");
            }
            else {
                habitat.TipoHabitat = tipoHabitat;


              
            }
            _context.Habitats.Add(habitat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitat", new { id = habitat.IdHabitat }, habitat);


        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> UpdateHabitat(int id, Habitat habitat)
        {
            if (id != habitat.IdHabitat)
            {
                return BadRequest();
            }

            _context.Entry(habitat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitatExists(id))
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
        public async Task<IActionResult> DeleteHabitat(int id)
        {
            var habitat = await _context.Habitats.FindAsync(id);
            if (habitat == null)
            {
                return NotFound();
            }

            _context.Habitats.Remove(habitat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitatExists(int id)
        {
            return _context.Habitats.Any(h => h.IdHabitat == id);
        }
    }
}

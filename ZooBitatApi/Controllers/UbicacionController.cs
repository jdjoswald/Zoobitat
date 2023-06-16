using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public UbicacionController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ubicacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ubicacion>>> GetUbicaciones()
        {
            return await _context.Ubicaciones.ToListAsync();
        }

        // GET: api/ubicacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ubicacion>> GetUbicacion(int id)
        {
            var ubicacion = await _context.Ubicaciones.FindAsync(id);

            if (ubicacion == null)
            {
                return NotFound();
            }

            return ubicacion;
        }

        // POST: api/ubicacion
        [HttpPost]
        public async Task<ActionResult<Ubicacion>> CreateUbicacion(Ubicacion ubicacion)
        {
            _context.Ubicaciones.Add(ubicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUbicacion), new { id = ubicacion.Id }, ubicacion);
        }

        // PUT: api/ubicacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUbicacion(int id, Ubicacion ubicacion)
        {
            if (id != ubicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(ubicacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ubicacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUbicacion(int id)
        {
            var ubicacion = await _context.Ubicaciones.FindAsync(id);
            if (ubicacion == null)
            {
                return NotFound();
            }

            _context.Ubicaciones.Remove(ubicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EstadoController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _context.Estados.ToListAsync();
        }

        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Estado>> GetEstado(string id)
        {
            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Estado>> CreateEstado(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = estado.IdEstado }, estado);
        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> UpdateEstado(int id, Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> DeleteEstado(string id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(t => t.IdEstado == id);
        }
    }
}

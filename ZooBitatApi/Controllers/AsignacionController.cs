using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public AsignacionController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Asignacion
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<IEnumerable<Asignacion>>> GetAsignaciones()
        {
            return await _context.Asignaciones.ToListAsync();
        }

        // GET: api/Asignacion/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Asignacion>> GetAsignacion(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);

            if (asignacion == null)
            {
                return NotFound();
            }

            return asignacion;
        }

        // POST: api/Asignacion
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Asignacion>> CreateAsignacion(Asignacion asignacion)
        {
            _context.Asignaciones.Add(asignacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsignacion), new { id = asignacion.IdAsignacion }, asignacion);
        }

        // PUT: api/Asignacion/5
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> UpdateAsignacion(int id, Asignacion asignacion)
        {
            if (id != asignacion.IdAsignacion)
            {
                return BadRequest();
            }

            _context.Entry(asignacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionExists(id))
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

        // DELETE: api/Asignacion/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> DeleteAsignacion(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }

            _context.Asignaciones.Remove(asignacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(a => a.IdAsignacion == id);
        }
    }
}


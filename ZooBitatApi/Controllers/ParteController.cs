using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParteController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ParteController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parte
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<IEnumerable<Parte>>> GetPartes()
        {
            var partes = await _context.Partes.Include(p => p.Animal).ToListAsync();
            return partes;
        }

        // GET: api/Parte/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Parte>> GetParte(int id)
        {
            var parte = await _context.Partes.Include(p => p.Animal).FirstOrDefaultAsync(p => p.IdParte == id);

            if (parte == null)
            {
                return NotFound();
            }

            return parte;
        }


        // POST: api/Parte
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Parte>> CreateParte(Parte parte)
        {
            // Buscar el animal por el IdAnimal
            var animal = await _context.Animales.FindAsync(parte.IdAnimal);
            if (animal == null)
            {
                return BadRequest("El animal especificado no existe.");
            }

            parte.Animal = animal;

            _context.Partes.Add(parte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParte), new { id = parte.IdParte }, parte);
        }


        // PUT: api/Parte/5
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> UpdateParte(int id, Parte parte)
        {
            if (id != parte.IdParte)
            {
                return BadRequest();
            }

            _context.Entry(parte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteExists(id))
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

        // DELETE: api/Parte/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> DeleteParte(int id)
        {
            var parte = await _context.Partes.FindAsync(id);
            if (parte == null)
            {
                return NotFound();
            }

            _context.Partes.Remove(parte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParteExists(int id)
        {
            return _context.Partes.Any(p => p.IdParte == id);
        }

        // PATCH: api/Parte/ChangeEstado/5
        [HttpPatch("ChangeEstado/{idParte}/{estado}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> ChangeParteEstado(int idParte, int estado)
        {
            var parte = await _context.Partes.FindAsync(idParte);
            if (parte == null)
            {
                return NotFound();
            }

            parte.estado = estado;

            _context.Entry(parte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParteExists(idParte))
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

    }
}

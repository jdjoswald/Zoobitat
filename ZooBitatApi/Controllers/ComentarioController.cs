using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ComentarioController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comentario
        [HttpGet]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
            return await _context.Comentarios.ToListAsync();
        }

        // GET: api/Comentario/5
        [HttpGet("{id}")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        // POST: api/Comentario
        [HttpPost]
        public async Task<ActionResult<Comentario>> CreateComentario(Comentario comentario)
        {
            // Establecer el estado como 0
            comentario.Estado = true;

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComentario), new { id = comentario.IdComentario }, comentario);
        }

        // PUT: api/Comentario/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> UpdateComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            // Cambiar el estado de true a false
            comentario.Estado = false;

            _context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
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


        // DELETE: api/Comentario/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(c => c.IdComentario == id);
        }
    }
}


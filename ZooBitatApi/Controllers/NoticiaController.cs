using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;
using System.Security.Claims;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public NoticiaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<Noticia>>> GetNoticias()
        {
            return await _context.Noticias.ToListAsync();
        }

        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<Noticia>> GetNoticia(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);

            if (noticia == null)
            {
                return NotFound();
            }

            return noticia;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Noticia>> CreateNoticia(Noticia noticia)
        {
            // Verificar si el usuario especificado existe en la base de datos
           




            var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(usuarioId))
            {
                return BadRequest("No se pudo obtener el ID del usuario mandante desde el token.");
            }

            // Verificar si el ID del usuario mandante es válido
            if (!int.TryParse(usuarioId, out int usuarioIdParsed))
            {
                return BadRequest("El ID del usuario mandante en el token no es válido.");
            }

            // Obtener el usuario mandante de la base de datos
            var usuario = await _context.Usuarios.FindAsync(usuarioIdParsed);
            if (usuario == null)
            {
                return BadRequest("El usuario mandante especificado en el token no existe.");
            }

            // Asignar el usuario existente a la noticia
            noticia.IdUsuario = usuarioIdParsed;
            noticia.Usuario = usuario;
            noticia.Fecha= DateTime.Now;
            _context.Noticias.Add(noticia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoticia", new { id = noticia.IdNotica }, noticia);
        }


        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> UpdateNoticia(int id, Noticia noticia)
        {
            if (id != noticia.IdNotica)
            {
                return BadRequest();
            }

            _context.Entry(noticia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticiaExists(id))
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
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> DeleteNoticia(int id)
        {
            var noticia = await _context.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }

            _context.Noticias.Remove(noticia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoticiaExists(int id)
        {
            return _context.Noticias.Any(n => n.IdNotica == id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesUsuarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public AsignacionesUsuarioController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionseUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignacionseUsuarios>>> GetAsignacionseUsuarios()
        {
            return await _context.AsignacionesUsuarios
                .Include(a => a.Usuario)
                .Include(a => a.Animal)
                .Include(a => a.EstadoAsignacion)
                .ToListAsync();
        }

        // GET: api/AsignacionseUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignacionseUsuarios>> GetAsignacionseUsuario(int id)
        {
            var asignacionseUsuario = await _context.AsignacionesUsuarios
                .Include(a => a.Usuario)
                .Include(a => a.Animal)
                .Include(a => a.EstadoAsignacion)
                .FirstOrDefaultAsync(a => a.IdAsignacion == id);

            if (asignacionseUsuario == null)
            {
                return NotFound();
            }

            return asignacionseUsuario;
        }

        // POST: api/AsignacionseUsuarios
        [HttpPost]
        public async Task<ActionResult<AsignacionseUsuarios>> CreateAsignacionseUsuario(AsignacionseUsuarios asignacionseUsuario)
        {
            // Verificar si el usuario existe
            var usuario = await _context.Usuarios.FindAsync(asignacionseUsuario.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("El usuario especificado no existe.");
            }

            // Verificar si el animal existe
            var animal = await _context.Animales.FindAsync(asignacionseUsuario.IdAnimal);
            if (animal == null)
            {
                return BadRequest("El animal especificado no existe.");
            }

            // Verificar si el estado de asignación existe
            var estadoAsignacion = await _context.EstadosAsignacion.FindAsync(asignacionseUsuario.IdEstadoAsignacion);
            if (estadoAsignacion == null)
            {
                return BadRequest("El estado de asignación especificado no existe.");
            }

            // Verificar si la asignación existe
            var asignacion = await _context.Asignaciones.FindAsync(asignacionseUsuario.IdAsignacion);
            if (asignacion == null)
            {
                return BadRequest("La asignación especificada no existe.");
            }

            // Asignar las entidades existentes a la asignación de usuario
            asignacionseUsuario.Usuario = usuario;
            asignacionseUsuario.Animal = animal;
            asignacionseUsuario.EstadoAsignacion = estadoAsignacion;
            asignacionseUsuario.Asignacion = asignacion;

            _context.AsignacionesUsuarios.Add(asignacionseUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsignacionseUsuario), new { id = asignacionseUsuario.IdAsignacion }, asignacionseUsuario);
        }

        // PUT: api/AsignacionseUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsignacionseUsuario(int id, AsignacionseUsuarios asignacionseUsuario)
        {
            if (id != asignacionseUsuario.IdAsignacion)
            {
                return BadRequest();
            }

            // Verificar si el estado de asignación existe
            var estadoAsignacion = await _context.EstadosAsignacion.FindAsync(asignacionseUsuario.IdEstadoAsignacion);
            if (estadoAsignacion == null)
            {
                return BadRequest("El estado de asignación especificado no existe.");
            }

            asignacionseUsuario.EstadoAsignacion = estadoAsignacion;

            _context.Entry(asignacionseUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionseUsuarioExists(id))
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

        // DELETE: api/AsignacionseUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacionseUsuario(int id)
        {
            var asignacionseUsuario = await _context.AsignacionesUsuarios.FindAsync(id);
            if (asignacionseUsuario == null)
            {
                return NotFound();
            }

            _context.AsignacionesUsuarios.Remove(asignacionseUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacionseUsuarioExists(int id)
        {
            return _context.AsignacionesUsuarios.Any(a => a.IdAsignacion == id);
        }
    }
}


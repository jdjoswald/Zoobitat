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
    public class AsignacionesUsuarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public AsignacionesUsuarioController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionseUsuarios
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<AsignacionseUsuarios>>> GetAsignacionseUsuarios()
        {
            return await _context.AsignacionesUsuarios.ToListAsync();
        }

        // GET: api/AsignacionseUsuarios/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<AsignacionseUsuarios>> GetAsignacionseUsuario(int id)
        {
            var asignacionseUsuario = await _context.AsignacionesUsuarios.FindAsync(id);

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
            var usuario = await _context.Usuarios.FindAsync(asignacionseUsuario.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("El ID de Usuario es inválido.");
            }

            var usuarioMandante = await _context.Usuarios.FindAsync(asignacionseUsuario.IdUsuarioMandante);
            if (usuarioMandante == null)
            {
                return BadRequest("El ID de UsuarioMandante es inválido.");
            }

            var animal = await _context.Animales.FindAsync(asignacionseUsuario.IdAnimal);
            if (animal == null)
            {
                return BadRequest("El ID de Animal es inválido.");
            }

            var estadoAsignacion = await _context.EstadosAsignacion.FindAsync(asignacionseUsuario.IdEstadoAsignacion);
            if (estadoAsignacion == null)
            {
                return BadRequest("El ID de EstadoAsignacion es inválido.");
            }

            var asignacion = await _context.Asignaciones.FindAsync(asignacionseUsuario.IdAsignacion);
            if (asignacion == null)
            {
                return BadRequest("El ID de Asignacion es inválido.");
            }

            asignacionseUsuario.Usuario = usuario;
            asignacionseUsuario.UsuarioMandante = usuarioMandante;
            asignacionseUsuario.Animal = animal;
            asignacionseUsuario.EstadoAsignacion = estadoAsignacion;
            asignacionseUsuario.Asignacion = asignacion;

            _context.AsignacionesUsuarios.Add(asignacionseUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsignacionseUsuario), new { id = asignacionseUsuario.IdAsignacionUsuario }, asignacionseUsuario);
        }



        // PUT: api/AsignacionseUsuarios/5
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<IActionResult> UpdateAsignacionseUsuario(int id, AsignacionseUsuarios asignacionseUsuario)
        {
            if (id != asignacionseUsuario.IdAsignacionUsuario)
            {
                return BadRequest();
            }

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
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
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
            return _context.AsignacionesUsuarios.Any(e => e.IdAsignacionUsuario == id);
        }

        // PUT: api/AsignacionseUsuarios/ChangeEstado/{estadoId}/{asignacionUsuarioId}
        [HttpPut("ChangeEstado/{estadoId}/{asignacionUsuarioId}")]
        [Authorize(Roles = "1,2,3")]
        public async Task<IActionResult> ChangeEstado(int estadoId, int asignacionUsuarioId)
        {
            var asignacionUsuario = await _context.AsignacionesUsuarios.FindAsync(asignacionUsuarioId);
            if (asignacionUsuario == null)
            {
                return NotFound("No se encontró la asignación de usuario");
            }

            var estadoAsignacion = await _context.EstadosAsignacion.FindAsync(estadoId);
            if (estadoAsignacion == null)
            {
                return NotFound("No se encontró el estado de asignación");
            }

            asignacionUsuario.IdEstadoAsignacion = estadoAsignacion.IdEstadoAsignacion;
            _context.Entry(asignacionUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/AsignacionseUsuarios/GetByUsuarioId/{usuarioId}
        [HttpGet("GetByUsuarioId/{usuarioId}")]
        [Authorize(Roles = "1,2,3")]
        public IActionResult GetByUsuarioId(int usuarioId)
        {
            var asignaciones = _context.AsignacionesUsuarios
                .Where(a => a.IdUsuario == usuarioId)
                .ToList();

            if (asignaciones.Count == 0)
            {
                return NotFound("No se encontraron asignaciones de usuario para el ID de usuario proporcionado");
            }

            return Ok(asignaciones);
        }
        [HttpGet("GetByEstadoId/{estadoId}")]
        [Authorize(Roles = "1,3")]
        public IActionResult GetByEstadoId(int estadoId)
        {
            var asignaciones = _context.AsignacionesUsuarios
                .Where(a => a.IdEstadoAsignacion == estadoId)
                .ToList();

            if (asignaciones.Count == 0)
            {
                return NotFound("No se encontraron asignaciones de usuario para el ID de estado proporcionado");
            }

            return Ok(asignaciones);
        }
        // GET: api/AsignacionseUsuarios/GetByUsuarioAndEstado/{usuarioId}/{estadoId}
        [HttpGet("GetByUsuarioAndEstado/{usuarioId}/{estadoId}")]
        [Authorize(Roles = "1,2,3")]
        public IActionResult GetByUsuarioAndEstado(int usuarioId, int estadoId)
        {
            var asignaciones = _context.AsignacionesUsuarios
                .Where(a => a.IdUsuario == usuarioId && a.IdEstadoAsignacion == estadoId)
                .ToList();

            if (asignaciones.Count == 0)
            {
                return NotFound("No se encontraron asignaciones de usuario para el ID de usuario y ID de estado proporcionados");
            }

            return Ok(asignaciones);
        }


    }
}



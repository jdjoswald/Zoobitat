using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {

        private readonly AplicationDbContext _context;

        public ActividadesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Actividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividades>>> GetActividades()
        {
            return await _context.Actividades.ToListAsync();
        }

        // GET: api/Actividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividades>> GetActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // POST: api/Actividades
        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Actividades>> CreateActividad(Actividades actividad)
        {

            // Obtener el ID del usuario mandante desde el token
            var usuarioMandanteId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(usuarioMandanteId))
            {
                return BadRequest("No se pudo obtener el ID del usuario mandante desde el token.");
            }

            // Verificar si el ID del usuario mandante es válido
            if (!int.TryParse(usuarioMandanteId, out int usuarioMandanteIdParsed))
            {
                return BadRequest("El ID del usuario mandante en el token no es válido.");
            }

            // Obtener el usuario mandante de la base de datos
            var usuarioMandante = await _context.Usuarios.FindAsync(usuarioMandanteIdParsed);
            if (usuarioMandante == null)
            {
                return BadRequest("El usuario mandante especificado en el token no existe.");
            }
            // Obtener el id de usuario del token y asignarlo a la propiedad IdUsuario
            int idUsuario = usuarioMandanteIdParsed;
            actividad.IdUsuario = idUsuario;

            // Verificar si la ubicación existe en la base de datos
            var ubicacion = await _context.Ubicaciones.FindAsync(actividad.IdUbicacion);
            if (ubicacion == null)
            {
                return BadRequest("La ubicación especificada no existe.");
            }

            // Asignar la ubicación existente a la actividad
            actividad.Ubicacion = ubicacion;
            actividad.usuario= await _context.Usuarios.FindAsync(idUsuario);
            _context.Actividades.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActividad), new { id = actividad.Id }, actividad);
        }

        // PUT: api/Actividades/5
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> UpdateActividad(int id, Actividades actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            // Verificar si la actividad existe en la base de datos
            var actividadExistente = await _context.Actividades.FindAsync(id);
            if (actividadExistente == null)
            {
                return NotFound();
            }

            // Obtener el id de usuario del token y asignarlo a la propiedad IdUsuario
            // Obtener el ID del usuario mandante desde el token
            var usuarioMandanteId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(usuarioMandanteId))
            {
                return BadRequest("No se pudo obtener el ID del usuario mandante desde el token.");
            }

            // Verificar si el ID del usuario mandante es válido
            if (!int.TryParse(usuarioMandanteId, out int usuarioMandanteIdParsed))
            {
                return BadRequest("El ID del usuario mandante en el token no es válido.");
            }

            // Obtener el usuario mandante de la base de datos
            var usuarioMandante = await _context.Usuarios.FindAsync(usuarioMandanteIdParsed);
            if (usuarioMandante == null)
            {
                return BadRequest("El usuario mandante especificado en el token no existe.");
            }
            // Obtener el id de usuario del token y asignarlo a la propiedad IdUsuario
            int idUsuario = usuarioMandanteIdParsed;
            actividad.IdUsuario = idUsuario;
            
            // Verificar si la ubicación existe en la base de datos
            var ubicacion = await _context.Ubicaciones.FindAsync(actividad.IdUbicacion);
            if (ubicacion == null)
            {
                return BadRequest("La ubicación especificada no existe.");
            }

            // Asignar la ubicación existente a la actividad
            actividad.Ubicacion = ubicacion;
            actividad.usuario = await _context.Usuarios.FindAsync(idUsuario);

            _context.Entry(actividadExistente).State = EntityState.Detached;
            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
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

        // DELETE: api/Actividades/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("actividades/semana-actual")]
        public ActionResult<List<Actividades>> ObtenerActividadesSemanaActual()
        {
            // Obtener la fecha actual
            var fechaActual = DateTime.Today;

            // Obtener el primer día de la semana actual (Lunes)
            var primerDiaSemanaActual = fechaActual.AddDays(-(int)fechaActual.DayOfWeek + 1);

            // Obtener el último día de la semana actual (Domingo)
            var ultimoDiaSemanaActual = primerDiaSemanaActual.AddDays(6);

            // Consultar las actividades dentro del rango de fechas de la semana actual incluyendo la ubicación
            var actividadesSemanaActual = _context.Actividades
                .Include(a => a.Ubicacion)
                .Where(a => a.Fecha >= primerDiaSemanaActual && a.Fecha <= ultimoDiaSemanaActual)
                .ToList();

            return actividadesSemanaActual;
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(e => e.Id == id);
        }

       
    }
}


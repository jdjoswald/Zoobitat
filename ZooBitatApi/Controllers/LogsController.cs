using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        private readonly AplicationDbContext _dbContext;

        public LogsController(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Log>> CreateLog(Log log)
        {
            // Obtener el ID del usuario mandante desde el token (si existe)
            var usuarioMandanteId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int us = 4; // Valor predeterminado si no se encuentra el ID en el token

            // Si el ID del usuario mandante se encontró en el token y se pudo parsear correctamente, lo asignamos a la variable "us"
            if (!string.IsNullOrEmpty(usuarioMandanteId) && int.TryParse(usuarioMandanteId, out us))
            {
                // Obtener el usuario mandante de la base de datos
                var usuarioMandante = await _dbContext.Usuarios.FindAsync(us);
                if (usuarioMandante == null)
                {
                    return BadRequest("El usuario mandante especificado en el token no existe.");
                }

                log.IdUsuario = us;
                log.Usuario = usuarioMandante;
            }
            else
            {
                // Si no se encontró el ID en el token, asignamos manualmente el ID 4 y buscamos el usuario correspondiente en la base de datos
                log.IdUsuario = 4;
                var usuario = await _dbContext.Usuarios.FindAsync(log.IdUsuario);

                // Asignar el usuario correspondiente al log
                if (usuario == null)
                {
                    return BadRequest("El usuario con ID 4 no existe en la base de datos.");
                }
                log.Usuario = usuario;
            }

            log.Timestamp = DateTime.Now;

            // Validar los datos del log si es necesario
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Guardar el log en la base de datos
            _dbContext.Logs.Add(log);
            _dbContext.SaveChanges();

            return Ok();
        }


        [HttpGet]
        public IActionResult GetLogs()
        {
            // Obtener todos los logs de la base de datos
            var logs = _dbContext.Logs.ToList();

            return Ok(logs);
        }
    }
}

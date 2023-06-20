using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateLog(Log log)
        {

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

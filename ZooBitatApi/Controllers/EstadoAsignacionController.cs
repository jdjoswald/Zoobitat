using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAsignacionController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EstadoAsignacionController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoAsignacion
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<EstadoAsignacion>>> GetEstadosAsignacion()
        {
            return await _context.EstadosAsignacion.ToListAsync();
        }

        // GET: api/EstadoAsignacion/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<EstadoAsignacion>> GetEstadoAsignacion(int id)
        {
            var estadoAsignacion = await _context.EstadosAsignacion.FindAsync(id);

            if (estadoAsignacion == null)
            {
                return NotFound();
            }

            return estadoAsignacion;
        }
    }
}

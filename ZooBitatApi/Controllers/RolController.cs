using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public RolController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Rol
        [HttpGet]
        [EnableCors("CorsPolicy")]

        public ActionResult<IEnumerable<Rol>> GetRoles()
        {
            var roles = _context.Roles;

            return Ok(roles);
        }
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public ActionResult<Rol> GetRolById(int id)
        {
            var rol = _context.Roles.Find(id);

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }
    }
}

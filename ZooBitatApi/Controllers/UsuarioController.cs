using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public UsuarioController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();

            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public ActionResult<Usuario> GetUsuarioById(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: api/Usuario
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult<Usuario> CreateUsuario(Usuario usuario)
        {
            // Obtener el rol correspondiente de la base de datos
            var rol = _context.Roles.FirstOrDefault(r => r.IdRol == usuario.IdRol);

            if (rol == null)
            {
                // Si el rol no existe, puedes manejar el error o devolver una respuesta de error
                return NotFound("El rol especificado no existe.");
            }

            // Asignar el rol al usuario
            usuario.Rol = rol;

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.IdUsuario }, usuario);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

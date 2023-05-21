using System.Security.Cryptography;
using System.Text;
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
            var usuarios = _context.Usuarios.Include(h=>h.Rol).ToList();

            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        public ActionResult<Usuario> GetUsuarioById(int id)
        {
            var usuario = _context.Usuarios.Include(h=>h.Rol).FirstOrDefaultAsync(h=>h.IdUsuario==id);

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

            // Encriptar la contraseña antes de guardarla
            usuario.Contrasenna = EncriptarContraseña(usuario.Contrasenna);

            // Asignar el rol al usuario
            usuario.Rol = rol;
            usuario.asignaciones = new List<Asignacion>();

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.IdUsuario }, usuario);
        }

        private string EncriptarContraseña(string contraseña)
        {
            // Aquí puedes utilizar un algoritmo de hash seguro, como bcrypt o PBKDF2
            // Asegúrate de incluir la lógica de encriptación adecuada, como salting y stretching

            // Ejemplo de encriptación simple utilizando SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
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

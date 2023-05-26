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


        // POST: api/Usuario/Login
        [HttpPost("Login")]
        [EnableCors("CorsPolicy")]
        public IActionResult Login(Usuario usuarioLogin)
        {
            // Buscar el usuario en la base de datos por nombre de usuario
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == usuarioLogin.Email);

            if (usuario == null)
            {
                // Si el usuario no existe, puedes manejar el error o devolver una respuesta de error
                return NotFound("Nombre de usuario incorrecto");
            }

            // Verificar la contraseña encriptada
            if (!VerificarContraseña(usuarioLogin.Contrasenna, usuario.Contrasenna))
            {
                // Si la contraseña no coincide, puedes manejar el error o devolver una respuesta de error
                return Unauthorized("Contraseña incorrecta");
            }

            // Devolver una respuesta exitosa con los datos del usuario
            return Ok(usuario);
        }

        private bool VerificarContraseña(string contraseña, string contraseñaEncriptada)
        {
            // Aquí debes implementar la lógica para verificar la contraseña encriptada con la contraseña proporcionada
            // Puedes utilizar el mismo algoritmo de encriptación utilizado en el método EncriptarContraseña

            // Por ejemplo, utilizando SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha256.ComputeHash(bytes);
                string contraseñaEncriptadaInput = Convert.ToBase64String(hash);
                return contraseñaEncriptada == contraseñaEncriptadaInput;
            }
        }



        /* // POST: api/Usuario/Login
         [HttpPost("Login")]
         [EnableCors("CorsPolicy")]
         public IActionResult Login(UsuarioLogin usuarioLogin)
         {
             // Buscar el usuario en la base de datos por nombre de usuario
             var usuario = _context.Usuarios.Include(h => h.Rol)
                                            .FirstOrDefault(u => u.NombreUsuario == usuarioLogin.NombreUsuario);

             if (usuario == null)
             {
                 // Si el usuario no existe, puedes manejar el error o devolver una respuesta de error
                 return NotFound("Nombre de usuario incorrecto");
             }

             // Verificar la contraseña encriptada
             if (!VerificarContraseña(usuarioLogin.Contrasenna, usuario.Contrasenna))
             {
                 // Si la contraseña no coincide, puedes manejar el error o devolver una respuesta de error
                 return Unauthorized("Contraseña incorrecta");
             }

             // Aquí puedes generar un token de autenticación utilizando tu método preferido
             // Por ejemplo, puedes utilizar JSON Web Tokens (JWT) para generar un token seguro y firmado

             // Devolver una respuesta exitosa con el token de autenticación
             var token = GenerateToken(usuario.IdUsuario, usuario.NombreUsuario, usuario.Rol.Nombre);
             return Ok(new { token });
         }

         private bool VerificarContraseña(string contraseña, string contraseñaEncriptada)
         {
             // Aquí debes implementar la lógica para verificar la contraseña encriptada con la contraseña proporcionada
             // Puedes utilizar el mismo algoritmo de encriptación utilizado en el método EncriptarContraseña

             // Por ejemplo, utilizando SHA256
             using (SHA256 sha256 = SHA256.Create())
             {
                 byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                 byte[] hash = sha256.ComputeHash(bytes);
                 string contraseñaEncriptadaInput = Convert.ToBase64String(hash);
                 return contraseñaEncriptada == contraseñaEncriptadaInput;
             }
         }

         private string GenerateToken(int userId, string username, string role)
         {
             // Aquí debes implementar la generación de un token de autenticación válido
             // Puedes utilizar una biblioteca como System.IdentityModel.Tokens.Jwt para generar y firmar el token

             // Por ejemplo:
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes("TuClaveSecreta"); // Reemplaza "TuClaveSecreta" con tu propia clave secreta
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
             new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
             new Claim(ClaimTypes.Name, username),
             new Claim(ClaimTypes.Role, role)
         }),
                 Expires = DateTime.UtcNow.AddDays(7), // Establece la fecha de vencimiento del token
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             return tokenHandler.WriteToken(token);
         }*/

    }
}

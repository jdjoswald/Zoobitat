using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "1,3")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = _context.Usuarios
        .Include(h => h.Rol)
        .Where(u => u.IdRol != 5 && u.IdRol != 6)
        .ToList();

            return Ok(usuarios);
        }

        [HttpGet("usuarios/rol5")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public ActionResult<IEnumerable<Usuario>> GetUsuariosRol5()
        {
            var usuariosRol5 = _context.Usuarios
                .Include(h => h.Rol)
                .Where(u => u.IdRol == 5)
                .ToList();

            return Ok(usuariosRol5);
        }

        [HttpGet("usuarios-por-rol/{idRol}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public ActionResult<IEnumerable<Usuario>> GetUsuariosPorRol(int idRol)
        {
            var usuarios = _context.Usuarios
                .Where(u => u.IdRol == idRol)
                .ToList();

            return Ok(usuarios);
        }


        [HttpGet("usuariosempl")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public ActionResult<IEnumerable<Usuario>> GetUsuariosEmpleado()
        {
            var usuarios = _context.Usuarios
                .Where(u => u.IdRol == 3 || u.IdRol ==2)
                .ToList();

            return Ok(usuarios);
        }


        // GET: api/Usuario/5
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuarios.Include(h => h.Rol).FirstOrDefaultAsync(h => h.IdUsuario == id);

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
            // Verificar si el correo ya existe en la base de datos
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);

            if (usuarioExistente != null)
            {
                // Si el usuario con el mismo correo ya existe, puedes manejar el error o devolver una respuesta de error
                return Conflict("El correo especificado ya está en uso.");
            }

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

            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Apellido = usuario.Apellido;

            _context.Entry(usuarioExistente).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id}/{idRol}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public IActionResult UpdateUsuarioIdRol(int id, int idRol)

        {
           
            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var rol = _context.Roles.FirstOrDefault(r => r.IdRol == idRol);

            if (rol == null)
            {
                return NotFound("El rol especificado no existe.");
            }

            usuario.IdRol = idRol;
            usuario.Rol = rol;

            _context.SaveChanges();

            return NoContent();
        }



        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles = "1,3")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            // Obtener el rol con el ID 5
            var rol = _context.Roles.Find(6);

            if (rol == null)
            {
                return NotFound("El rol especificado no existe.");
            }

            // Asignar el nuevo rol al usuario
            usuario.IdRol = rol.IdRol;
            usuario.Rol = rol;
            


            _context.SaveChanges();

            return NoContent();
        }


       /*// POST: api/Usuario/Login
        [HttpPost("Login")]
        [EnableCors("CorsPolicy")]
        public IActionResult Login(string email, string contrasenna)
        {
            // Buscar el usuario en la base de datos por email
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                // Si el usuario no existe, puedes manejar el error o devolver una respuesta de error
                return NotFound("Email incorrecto");
            }

            // Verificar si el usuario tiene el rol 5
            if (usuario.Rol.IdRol == 5)
            {
                // Si el usuario tiene el rol 5, devolver una respuesta de error o manejarlo según tus necesidades
                return Unauthorized("Acceso denegado");
            }

            // Verificar la contraseña encriptada
            if (!VerificarContraseña(contrasenna, usuario.Contrasenna))
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

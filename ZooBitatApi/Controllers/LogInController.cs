using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZooBitatApi.Models;

namespace ZooBitatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {


        private readonly AplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LogInController(AplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // POST: api/Usuario/Login
        [HttpPost("Login")]
        [EnableCors("CorsPolicy")]
        public IActionResult Login(LoginModel log)
        {
           

            // Buscar el usuario en la base de datos por email
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == log.Email);

            if (usuario == null)
            {
                // Si el usuario no existe, puedes manejar el error o devolver una respuesta de error
                return NotFound("Email incorrecto");
            }

            // Verificar si el usuario tiene el rol 5
            if (usuario.IdRol == 5|| usuario.IdRol == 6)
            {
                // Si el usuario tiene el rol 5, devolver una respuesta de error o manejarlo según tus necesidades
                return Unauthorized("Acceso denegado");
            }

            // Verificar la contraseña encriptada
            if (!VerificarContraseña(log.contrasenna, usuario.Contrasenna))
            {
                // Si la contraseña no coincide, puedes manejar el error o devolver una respuesta de error
                return Unauthorized("Contraseña incorrecta");
            }

            var token = generatetoken(usuario);

            // Devolver una respuesta exitosa con los datos del usuario
            return Ok(token);
        }

        private string generatetoken(Usuario usuario)
        {


           

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.IdRol.ToString())
            };


            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: credentials


            );



            return new JwtSecurityTokenHandler().WriteToken(token);


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

        [HttpGet("rol-token")]
        public ActionResult<string> ObtenerRolToken()
        {
            // Obtener el token del encabezado de autorización
            var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();
            var token = authorizationHeader?.Replace("Bearer ", "");

            // Verificar si se proporcionó un token
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("No se proporcionó un token válido.");
            }

            try
            {
                // Decodificar el token y obtener los claims
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenClaims = tokenHandler.ReadJwtToken(token).Claims;

                // Buscar el claim correspondiente al rol (usando ClaimTypes.Role)
                var rolClaim = tokenClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                // Verificar si se encontró el claim del rol
                if (rolClaim != null)
                {
                    var rol = rolClaim.Value;
                    return rol;
                }
                else
                {
                    return NotFound("No se encontró el claim del rol en el token.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al decodificar el token: {ex.Message}");
            }
        }



    }
}


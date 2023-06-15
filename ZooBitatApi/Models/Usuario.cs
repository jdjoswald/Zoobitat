using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ZooBitatApi.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contrasenna { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Rol?  Rol { get; set; }
        [JsonIgnore]
        public ICollection<Asignacion> asignaciones { get; set; } = new List<Asignacion>();

    }
}

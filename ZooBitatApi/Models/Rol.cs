using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

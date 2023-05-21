using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Asignacion
    {
        [Key]
        public int IdAsignacion { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

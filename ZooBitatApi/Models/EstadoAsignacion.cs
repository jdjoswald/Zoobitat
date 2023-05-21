using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class EstadoAsignacion
    {
        [Key]
        public int IdEstadoAsignacion { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class EstadoIncidencia
    {
        [Key]
        public int IdEstadoIncidencia { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

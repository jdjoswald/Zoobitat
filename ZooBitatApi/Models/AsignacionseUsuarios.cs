using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class AsignacionseUsuarios
    {
        [Key]
        public int IdAsignacion { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal Animal { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public int IdEstadoAsignacion { get; set; }
        [ForeignKey("IdEstadoAsignacion")]
        public EstadoAsignacion EstadoAsignacion { get; set; }
    }
}

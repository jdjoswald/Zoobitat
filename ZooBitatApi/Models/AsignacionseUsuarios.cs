using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class AsignacionseUsuarios
    {
        [Key]
        public int IdAsignacionUsuario { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
        [Required]
        public int IdUsuarioMandante { get; set; }
        [ForeignKey("IdUsuarioMandante")]
        public Usuario? UsuarioMandante { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal? Animal { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public int IdEstadoAsignacion { get; set; }
        [ForeignKey("IdEstadoAsignacion")]
        public EstadoAsignacion? EstadoAsignacion { get; set; }
        [Required]
        public int IdAsignacion { get; set; }
        [ForeignKey("IdAsignacion")]
        public Asignacion? Asignacion { get; set; }
        [Required]
        public string Notas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class Incidencia
    {
        [Key]
        public int IdIncidencia { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal Animal { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [Required]
        public int IdUsuarioMandante{ get; set; }
        [ForeignKey("IdUsuarioMandante")]
        public Usuario UsuarioMandante { get; set; }


        public string Notas { get; set; }
    }
}

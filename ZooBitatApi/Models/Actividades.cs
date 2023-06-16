using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class Actividades
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string foto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int IdUbicacion { get; set; }
        [ForeignKey("IdUbicacion")]
        public Ubicacion? Ubicacion { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? usuario { get; set; }


    }
}

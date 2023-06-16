using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }
        [Required]
        public String Correo { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String ComentarioText { get; set; }
        [Required]
        public bool Estado { get; set; }

    }
}

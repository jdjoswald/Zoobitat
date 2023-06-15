using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class Noticia
    {
        [Key]
        public int IdNotica { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Cuerpo { get; set; }
        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

    }
}

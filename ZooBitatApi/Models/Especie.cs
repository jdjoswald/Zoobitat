using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Especie
    {
        [Key]
        public int IdEspecie { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Informacion { get; set; }
        [Required]
        public string Icono { get; set; }
    }
}

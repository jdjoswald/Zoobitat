using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class Habitat
    {
        [Key]
        public int IdHabitat { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdTipoHabitat { get; set; }
        [ForeignKey("IdTipoHabitat")]
        public TipoHabitat? TipoHabitat { get; set; }
    }
}

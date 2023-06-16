using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Galeria
    {
        [Key]
        public int IdGaleria { get; set; }

        public int IdEspecie { get; set; }
        [ForeignKey("IdEspecie")]
        public Especie? Especie { get; set; }

        public string Imagen { get; set; }
    }
}

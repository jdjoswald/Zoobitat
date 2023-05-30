using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class Animal
    {
        [Key]
        public int IdAnimal { get; set; }
        [Required]
        public int IdEspecie { get; set; }
        [ForeignKey("IdEspecie")]
        public Especie Especie { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public int IdHabitat { get; set; }
        [ForeignKey("IdHabitat")]
        public Habitat Habitat { get; set; }
        [Required]
        public string Informacion { get; set; }
        [Required]
        public string Imagen { get; set; }

        [Required]
        public string Sexo { get; set; }
        [Required]
        public double peso { get; set; }
    }
}

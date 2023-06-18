using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class Parte
    {
        [Key]
        public int IdParte { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal? Animal { get; set; }

        [Required]
        public string Observaciones { get; set; }

        [Required]
        public int estado { get; set; }



    }
}

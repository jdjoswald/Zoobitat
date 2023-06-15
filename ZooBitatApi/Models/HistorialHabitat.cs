using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class HistorialHabitat
    {
        [Key]
        public int IdHistorialHabitat { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal? Animal { get; set; }
        public string Notas { get; set; }
    }
}

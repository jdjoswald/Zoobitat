using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooBitatApi.Models
{
    public class HistorialEstado
    {
        [Key]
        public int IdHistorialEstado { get; set; }
        [Required]
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public Estado? Estado { get; set; }  
        [Required]
        public DateTime FechaInicio { get; set; }
      
        [Required]
        public int IdAnimal { get; set; }
        [ForeignKey("IdAnimal")]
        public Animal? Animal { get; set; }

    }
}

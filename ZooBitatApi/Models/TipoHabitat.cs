using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ZooBitatApi.Models
{
    public class TipoHabitat
    {
        [Key]
        public int IdTipoHabitat { get; set; }
        [Required]
        public string Nombre { get; set; }
      

    }
}

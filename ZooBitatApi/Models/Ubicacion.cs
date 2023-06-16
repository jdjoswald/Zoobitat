using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Ubicacion
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

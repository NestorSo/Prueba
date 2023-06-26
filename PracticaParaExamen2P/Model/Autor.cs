using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class Autor
    {
        [Key]
        
        public int IdAutor { get; set; }
        [Required]
        [StringLength(20)]
           public string ? autor { get; set; }
    }
}

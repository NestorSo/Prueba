using System.ComponentModel.DataAnnotations;

namespace Prueba.Model.Dto
{
    public class AutorUpdateDto
    {

        [Key]

        public int IdAutor { get; set; }
        [Required]
        [StringLength(20)]
        public string? autor { get; set; }
    }
}

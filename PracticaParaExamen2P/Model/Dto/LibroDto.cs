using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Model.Dto
{
    public class LibroDto
    {

        [Key]
        [Required]
        [StringLength(13)]
        public string? ISBN { get; set; }
        [Required]
        [StringLength(20)]
        public string? Titulo { get; set; }
        [Required]
        public decimal? Precio { get; set; }
        [Required]
        public int IdAutor { get; set; }

        [Required]
        [StringLength(20)]
        public string? Categoria { get; set; }
        [Required]
        [StringLength(20)]
        public string? Editorial { get; set; }
        [Required]
        [StringLength(20)]
        public string? Existencia { get; set; }
    }

}

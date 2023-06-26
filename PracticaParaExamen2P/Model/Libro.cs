using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Model
{
    public class Libro
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
        [ForeignKey("IdAutor")]
        public Autor? Autor { get; set; }
        [Required]
        [StringLength(20)]
        public string? Categoria { get; set; }
        [Required]
        [StringLength(20)]
        public string ? Editorial { get; set; }
        [Required]
        [StringLength(20)]
        public int Existencia { get; set; }

    }
}

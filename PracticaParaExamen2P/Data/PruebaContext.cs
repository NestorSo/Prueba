using Microsoft.EntityFrameworkCore;
using Prueba.Model;
using System.Diagnostics;

namespace PracticaParaExamen2P.Data
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Libro>().HasData(
                 new Libro()
                 {
                     ISBN = "84-121-2310-1",
                     Titulo = "El tránsito terreno",
                     Precio = 700.00M,
                     IdAutor = 1,
                     Categoria = "Filosofia",
                     Editorial = "fíaLarrosa Mas, S.L.",
                     Existencia = 9
                 });
                 

            modelBuilder.Entity<Autor>().HasData(
                 new Autor()
                 {
                    IdAutor= 1,
                    autor= "Plasencia, Juan Luis"

                 }
                );
            

        }

    }
}

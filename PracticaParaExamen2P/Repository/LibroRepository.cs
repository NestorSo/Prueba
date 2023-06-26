using Microsoft.EntityFrameworkCore;
using PracticaParaExamen2P.Data;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Repository
{
    public class LibroRepository : Repository<Libro>, ILibrosRepository
    {
        private readonly PruebaContext _db;

        public LibroRepository(PruebaContext db) : base(db)
        {
            _db = db;

        }

        public async Task<Libro> Update(Libro enity)
        {
            _db.Libros.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}

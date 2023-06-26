using Microsoft.EntityFrameworkCore;
using PracticaParaExamen2P.Data;
using Prueba.Model;
using Prueba.Repository.IRepository;

namespace Prueba.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        private readonly PruebaContext _db;

        public AutorRepository(PruebaContext db) : base(db)
        {
            _db = db;

        }
        public async Task<Autor> Update(Autor enity)
        {
            _db.Autores.Update(enity);
            await _db.SaveChangesAsync();
            return enity;
        }
    }
}

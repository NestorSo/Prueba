using Microsoft.EntityFrameworkCore;
using PracticaParaExamen2P.Data;
using Prueba.Repository.IRepository;

namespace Prueba.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly PruebaContext _db;
        internal DbSet<T> dbSet;

        public Repository(PruebaContext db)
        {
            _db = db;
            dbSet = db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        public async Task<T>? Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>>? GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = (query.Where(filter));
            }
            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await Save();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}

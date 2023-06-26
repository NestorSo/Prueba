
using Prueba.Model;

namespace Prueba.Repository.IRepository
{
    public interface ILibrosRepository : IRepository<Libro>
    {
        Task<Libro> Update(Libro enity);
    }
}

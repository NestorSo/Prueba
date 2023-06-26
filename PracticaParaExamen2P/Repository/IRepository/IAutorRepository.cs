using Prueba.Model;

namespace Prueba.Repository.IRepository
{
    public interface IAutorRepository: IRepository<Autor>
    {
        Task<Autor> Update(Autor enity);
    }
}

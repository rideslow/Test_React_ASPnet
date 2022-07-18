using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tess_React_ASPnet.DAL.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<bool> Create(T entity);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPF_SimpleTrader.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Update(int id, T entity);

        Task<T> Create(T entity);

        Task<bool> Delete(int id);
    }
}
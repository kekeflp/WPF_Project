using System.Collections.Generic;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.Domain.Services
{
    public interface IDataService<T> where T : DomainObject
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}

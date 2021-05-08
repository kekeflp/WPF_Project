using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.Domain.Services
{
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}

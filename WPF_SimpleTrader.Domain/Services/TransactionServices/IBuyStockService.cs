using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        Task<Account> BuyStock(Account account, string stock, int shares);
    }
}

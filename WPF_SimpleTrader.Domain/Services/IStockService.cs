using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models.API;

namespace WPF_SimpleTrader.Domain.Services
{
    public interface IStockService
    {
        Task<double> GetPrice(string symbol);
        Task<StockResult> GetStock(string symbol);
    }
}

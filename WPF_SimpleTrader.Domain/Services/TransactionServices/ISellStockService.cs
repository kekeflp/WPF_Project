using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using System;
using WPF_SimpleTrader.Domain.Exceptions;

namespace WPF_SimpleTrader.Domain.Services.TransactionServices
{
    public interface ISellStockService
    {
        /// <summary>
        /// xxxxxxxxxxxxxxxxx
        /// </summary>
        /// <param name="seller"></param>
        /// <param name="symbol"></param>
        /// <param name="shares"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException">抛出用户未找到的异常</exception>
        /// <exception cref="InsufficientSharesException">抛出股份不足的异常</exception>
        /// <exception cref="Exception">抛出其他问题的异常</exception>
        Task<Account> SellStock(Account seller, string symbol, int shares);
    }
}

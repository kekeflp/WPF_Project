using System;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Models.API;

namespace WPF_SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockService _stockService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(IStockService stockService, IDataService<Account> accountService)
        {
            _stockService = stockService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account account, string stock, int shares)
        {
            StockResult stockInfo = await _stockService.GetStock(stock);
            double stockPrice = stockInfo.Price;

            // 先判断余额是否够, 如果不够，直接抛出异常并立即结束方法
            double transactionPrice = stockPrice * shares;

            if (transactionPrice > account.Balance)
            {
                throw new InsufficientFundsException(account.Balance, transactionPrice);
            }

            AssetTransaction transaction = new AssetTransaction()
            {
                Account = account,
                Asset = new Asset { Symbol = stock, PricePerShare = stockPrice },
                DateProcessed = DateTime.Now,
                Shares = shares,
                IsPurchase = true,
            };
            account.AssetTransactions.Add(transaction);
            account.Balance -= transactionPrice;
            await _accountService.Update(account.Id, account);
            return account;
        }
    }
}

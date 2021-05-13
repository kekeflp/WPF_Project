using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.Domain.Services.TransactionServices
{
    public class SellStockService : ISellStockService
    {
        readonly IStockService _stockService;
        private readonly IDataService<Account> _accountService;

        public SellStockService(IStockService stockService, IDataService<Account> accountService)
        {
            _stockService = stockService;
            _accountService = accountService;
        }

        public async Task<Account> SellStock(Account seller, string symbol, int shares)
        {
            // 验证 账户中是否 存在要出售的 股票
            // 获得 要出售的股票的价格
            // 给用户添加交易的相关 信息
            // 更新 当前用户
            int accountShares = GetAccountSharesForSymbol(seller, symbol);

            if (accountShares < shares)
            {
                throw new InsufficientSharesException(symbol, accountShares, shares);
            }

            double stockPrice = await _stockService.GetPrice(symbol);

            seller.AssetTransactions.Add(new AssetTransaction()
            {
                Account = seller,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                IsPurchase = false,
                Shares = shares
            });

            seller.Balance += stockPrice * shares;

            await _accountService.Update(seller.Id, seller);
            return seller;
        }

        private int GetAccountSharesForSymbol(Account seller, string symbol)
        {
            // 获取到账户中指定股票的所有交易信息
            IEnumerable<AssetTransaction> assetTransactionsForSymbol = seller.AssetTransactions.Where(a => a.Asset.Symbol == symbol);
            // 计算持有的指定股票的总数量
            return assetTransactionsForSymbol.Sum(a => a.IsPurchase ? a.Shares : -a.Shares);
        }
    }
}

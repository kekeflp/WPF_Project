using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using Xunit;

namespace WPF_SimpleTrader.Domain.Tests.Services.TransactionServices
{
    public class SellStockServiceTests
    {
        private readonly ISellStockService _sellStockService;
        private readonly Mock<IStockService> _mockStockService;
        private readonly Mock<IDataService<Account>> _mockAccountService;

        public SellStockServiceTests()
        {
            _mockStockService = new Mock<IStockService>();
            _mockAccountService = new Mock<IDataService<Account>>();
            _sellStockService = new SellStockService(_mockStockService.Object, _mockAccountService.Object);
        }

        private static Account CreateAccount(string symbol, int shares)
        {
            return new Account
            {
                AssetTransactions = new List<AssetTransaction>
                {
                    new AssetTransaction
                    {
                        Asset = new Asset
                        {
                            Symbol = symbol
                        },
                    IsPurchase = true,
                    Shares = shares
                    }
                }
            };
        }

        [Fact]
        public async Task SellStock_WithInsufficientShares_ThrowsInsufficientSharesException()
        {
            string expectedSymbol = "T";
            int expectedAccountShares = 0;
            int expectedRequiredShares = 10;
            Account seller = CreateAccount(expectedSymbol, expectedAccountShares);

            InsufficientSharesException exception =await Assert.ThrowsAsync<InsufficientSharesException>(() => _sellStockService.SellStock(seller, expectedSymbol, expectedRequiredShares));
            string actualSymbol = exception.Symbol;
            double actualAccountBalance = exception.AccountShares;
            double actualRequiredBalance = exception.RequiredShares;

            Assert.Equal(expectedSymbol, actualSymbol);
            Assert.Equal(expectedAccountShares, actualAccountBalance);
            Assert.Equal(expectedRequiredShares, actualRequiredBalance);
        }

        [Fact]
        public async Task SellStock_WithInvalidSymbol_ThrowsInvalidSymbolExceptionForSymbol()
        {
            string expectedInvalidSymbol = "bad_symbol";
            Account seller = CreateAccount(expectedInvalidSymbol, 10);
            _mockStockService.Setup(s => s.GetPrice(expectedInvalidSymbol)).ThrowsAsync(new InvalidSymbolException(expectedInvalidSymbol));

            InvalidSymbolException exception = await Assert.ThrowsAsync<InvalidSymbolException>(() => _sellStockService.SellStock(seller, expectedInvalidSymbol, 5));
            string actualInvalidSymbol = exception.Symbol;

            Assert.Equal(expectedInvalidSymbol, actualInvalidSymbol);
        }

        [Fact]
        public void SellStock_WithGetPriceFailure_ThrowsException()
        {
            Account seller = CreateAccount(It.IsAny<string>(), 10);
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(() => _sellStockService.SellStock(seller, It.IsAny<string>(), 5));
        }

        [Fact]
        public void SellStock_WithAccountUpdateFailure_ThrowsException()
        {
            Account seller = CreateAccount(It.IsAny<string>(), 10);
            _mockAccountService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Account>())).ThrowsAsync(new Exception());
            Assert.ThrowsAsync<Exception>(() => _sellStockService.SellStock(seller, It.IsAny<string>(), 5));
        }

        [Fact]
        public async Task SellStock_WithSuccessfulSell_ReturnsAccountWithNewTransaction()
        {
            int expectedTransactionCount = 2;
            Account seller = CreateAccount(It.IsAny<string>(), 10);

            seller = await _sellStockService.SellStock(seller, It.IsAny<string>(), 5);
            int actualTransactionCount = seller.AssetTransactions.Count;

            Assert.Equal(expectedTransactionCount, actualTransactionCount);
        }

        [Fact]
        public async Task SellStock_WithSuccessfulSell_ReturnsAccountWithNewBalance()
        {
            double expectedBalance = 100;
            Account seller = CreateAccount(It.IsAny<string>(), 10);
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(50);

            seller = await _sellStockService.SellStock(seller, It.IsAny<string>(), 2);
            double actualBalance = seller.Balance;

            Assert.Equal(expectedBalance, actualBalance);
        }


    }
}

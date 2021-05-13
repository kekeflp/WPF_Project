using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using Xunit;

namespace WPF_SimpleTrader.Domain.Tests.Services.TransactionServices
{
    public class BuyStockServiceTests
    {
        private readonly IBuyStockService _buyStockService;
        private readonly Mock<IStockService> _mockStockService;
        private readonly Mock<IDataService<Account>> _mockAccountService;

        public BuyStockServiceTests()
        {
            _mockStockService = new Mock<IStockService>();
            _mockAccountService = new Mock<IDataService<Account>>();
            _buyStockService = new BuyStockService(_mockStockService.Object, _mockAccountService.Object);
        }

        [Fact]
        public async Task BuyStock_WithInvalidSymbol_ThrowsInvalidSymbolExceptionForSymbol()
        {
            string expectedInvalidSymbol = "bad_symbol";
            _mockStockService.Setup(s => s.GetPrice(expectedInvalidSymbol)).ThrowsAsync(new InvalidSymbolException(expectedInvalidSymbol));

            InvalidSymbolException excpetion = await Assert.ThrowsAsync<InvalidSymbolException>(() => _buyStockService.BuyStock(It.IsAny<Account>(), expectedInvalidSymbol, It.IsAny<int>()));
            string actualInvalidSymbol = excpetion.Symbol;

            Assert.Equal(expectedInvalidSymbol, actualInvalidSymbol);
        }

        [Fact]
        public void BuyStock_WithGetPriceFailure_ThrowsException()
        {
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(() => _buyStockService.BuyStock(It.IsAny<Account>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        [Fact]
        public async Task BuyStock_WithInsufficientFunds_ThrowsInsufficientFundsExceptionForBalances()
        {
            double expectedAccountBalance = 0;
            double expectedRequiredBalance = 100;
            Account buyer = CreateAccount(expectedAccountBalance);
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(expectedRequiredBalance);

            InsufficientFundsException insufficientFundsException = await Assert.ThrowsAsync<InsufficientFundsException>(() => _buyStockService.BuyStock(buyer, It.IsAny<string>(), 1));
            InsufficientFundsException exception = insufficientFundsException;
            double actualAccountBalance = exception.AccountBalance;
            double actualRequiredBalance = exception.RequiredBalance;

            Assert.Equal(expectedAccountBalance, actualAccountBalance);
            Assert.Equal(expectedRequiredBalance, actualRequiredBalance);
        }

        [Fact]
        public void BuyStock_WithAccountUpdateFailure_ThrowsException()
        {
            Account buyer = CreateAccount(1000);
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(100);
            _mockAccountService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<Account>())).Throws(new Exception());

            Assert.ThrowsAsync<Exception>(() => _buyStockService.BuyStock(buyer, It.IsAny<string>(), 1));
        }

        [Fact]
        public async Task BuyStock_WithSuccessfulPurchase_ReturnsAccountWithNewTransaction()
        {
            int expectedTransactionCount = 1;
            Account buyer = CreateAccount(1000);
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(100);

            buyer = await _buyStockService.BuyStock(buyer, It.IsAny<string>(), 1);
            int actualTransactionCount = buyer.AssetTransactions.Count;

            Assert.Equal(expectedTransactionCount, actualTransactionCount);
        }

        [Fact]
        public async Task BuyStock_WithSuccessfulPurchase_ReturnsAccountWithNewBalance()
        {
            double expectedBalance = 0;
            Account buyer = CreateAccount(100);
            _mockStockService.Setup(s => s.GetPrice(It.IsAny<string>())).ReturnsAsync(50);

            buyer = await _buyStockService.BuyStock(buyer, It.IsAny<string>(), 2);
            double actualBalance = buyer.Balance;

            Assert.Equal(expectedBalance, actualBalance);
        }

        private Account CreateAccount(double balance)
        {
            return new Account()
            {
                Balance = balance,
                AssetTransactions = new List<AssetTransaction>()
            };
        }
    }
}
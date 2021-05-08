using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class BuyViewModelFactory : ISimpleTraderViewModelFactory<BuyViewModel>
    {
        private readonly IStockService _stockService;
        private readonly IBuyStockService _buyStockService;

        public BuyViewModelFactory(IStockService stockService, IBuyStockService buyStockService)
        {
            _stockService = stockService;
            _buyStockService = buyStockService;
        }
        public BuyViewModel CreateViewModel()
        {
            return new BuyViewModel(_stockService, _buyStockService);
        }
    }
}

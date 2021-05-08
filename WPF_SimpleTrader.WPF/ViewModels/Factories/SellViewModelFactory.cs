using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class SellViewModelFactory : ISimpleTraderViewModelFactory<SellViewModel>
    {
        //private readonly IStockService _stockService;
        //private readonly IBuyStockService _buyStockService;

        //public SellViewModelFactory(IStockService stockService, IBuyStockService buyStockService)
        //{
        //    _stockService = stockService;
        //    _buyStockService = buyStockService;
        //}

        public SellViewModel CreateViewModel()
        {
            return new SellViewModel();
        }
    }
}

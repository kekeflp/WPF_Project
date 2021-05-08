using System;
using WPF_SimpleTrader.WPF.State;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelFactory : ISimpleTraderViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<PortfolioViewModel> _createPortfolioViewModel;
        private readonly CreateViewModel<BuyViewModel> _createBuyViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        //private readonly CreateViewModel<SellViewModel> _createSellViewModel;

        public SimpleTraderViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel, CreateViewModel<PortfolioViewModel> createPortfolioViewModel, CreateViewModel<BuyViewModel> createBuyViewModel, CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createPortfolioViewModel = createPortfolioViewModel;
            _createBuyViewModel = createBuyViewModel;
            _createLoginViewModel = createLoginViewModel;
        }

        // 因为本例中所有的viewmodel都继承ObservableObject, 所有此处可以使用这个ObservableObject作为返回类型
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Portfolio:
                    return _createPortfolioViewModel();
                case ViewType.Buy:
                    return _createBuyViewModel();
                case ViewType.Sell:
                    //return _sellViewModelFactory.CreateViewModel();
                    return new SellViewModel();
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("没有与这个ViewType所对应的ViewModel", nameof(viewType));
            }
        }
    }
}

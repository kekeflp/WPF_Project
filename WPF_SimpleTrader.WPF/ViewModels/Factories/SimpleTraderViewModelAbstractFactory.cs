using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using WPF_SimpleTrader.WPF.State;
using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelAbstractFactory : ISimpleTraderViewModelAbstractFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<BuyViewModel> _buyViewModelFactory;
        //private readonly ISimpleTraderViewModelFactory<SellViewModel> _sellViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<LoginViewModel> _loginViewModelFactory;


        public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory, ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory, ISimpleTraderViewModelFactory<BuyViewModel> buyViewModelFactory, ISimpleTraderViewModelFactory<LoginViewModel> loginViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _buyViewModelFactory = buyViewModelFactory;
            //_sellViewModelFactory = sellViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
        }

        // 因为本例中所有的viewmodel都继承ObservableObject, 所有此处可以使用这个ObservableObject作为返回类型
        public ObservableObject CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModelFactory.CreateViewModel();
                case ViewType.Sell:
                    //return _sellViewModelFactory.CreateViewModel();
                    return new SellViewModel();
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("没有与这个ViewType所对应的ViewModel", nameof(viewType));
            }
        }
    }
}

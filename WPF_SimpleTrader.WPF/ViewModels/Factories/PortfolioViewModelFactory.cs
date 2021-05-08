using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory : ISimpleTraderViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }
}

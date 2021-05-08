using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : ISimpleTraderViewModelFactory<HomeViewModel>
    {
        private readonly ISimpleTraderViewModelFactory<MajorindexViewModel> _majorindexViewModelFactory;

        public HomeViewModelFactory(ISimpleTraderViewModelFactory<MajorindexViewModel> majorindexViewModelFactory)
        {
            _majorindexViewModelFactory = majorindexViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_majorindexViewModelFactory.CreateViewModel());
        }
    }
}

using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public class MajorindexViewModelFactory : ISimpleTraderViewModelFactory<MajorindexViewModel>
    {
        private readonly IMajorindexService _majorindexService;

        public MajorindexViewModelFactory(IMajorindexService majorindexService)
        {
            _majorindexService = majorindexService;
        }

        public MajorindexViewModel CreateViewModel()
        {
            return MajorindexViewModel.LoadMajorindexViewModel(_majorindexService);
        }
    }
}

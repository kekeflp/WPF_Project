using WPF_SimpleTrader.WPF.State;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelFactory
    {
        public ViewModelBase CreateViewModel(ViewType viewType);
    }
}

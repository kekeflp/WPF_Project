using Microsoft.Toolkit.Mvvm.ComponentModel;
using WPF_SimpleTrader.WPF.State;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface
{
    public interface ISimpleTraderViewModelAbstractFactory
    {
        public ObservableObject CreateViewModel(ViewType viewType);
    }
}

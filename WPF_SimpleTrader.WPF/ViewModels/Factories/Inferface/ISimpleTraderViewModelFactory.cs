using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface
{
    // 因为本例中所有的viewmodel都继承ObservableObject, 所有此处可以限制T为ObservableObject
    public interface ISimpleTraderViewModelFactory<T> where T: ObservableObject
    {
        T CreateViewModel();
    }
}

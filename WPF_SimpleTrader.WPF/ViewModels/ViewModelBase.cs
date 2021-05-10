using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    // 使用委托动态创建viewmodel，
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase : ObservableObject
    {
    }
}
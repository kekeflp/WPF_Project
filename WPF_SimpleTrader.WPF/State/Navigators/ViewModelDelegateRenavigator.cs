using WPF_SimpleTrader.WPF.ViewModels;

namespace WPF_SimpleTrader.WPF.State.Navigators
{
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel: ViewModelBase
    {
        readonly INavigator _navigator;
        readonly CreateViewModel<TViewModel> _viewModelFactory;

        public ViewModelDelegateRenavigator(INavigator navigator , CreateViewModel<TViewModel> viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentVM = _viewModelFactory();
        }
    }
}

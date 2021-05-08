using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SimpleTrader.WPF.ViewModels.Factories.Inferface;

namespace WPF_SimpleTrader.WPF.State.Navigators
{
    public class ViewModelFactoryRenavigator<TViewModel> : IRenavigator where TViewModel: ObservableObject
    {
        readonly INavigator _navigator;
        readonly ISimpleTraderViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelFactoryRenavigator(INavigator navigator, ISimpleTraderViewModelFactory<TViewModel> viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentVM = _viewModelFactory.CreateViewModel();
        }
    }
}

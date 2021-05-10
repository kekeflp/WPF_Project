using System;
using WPF_SimpleTrader.WPF.ViewModels;

namespace WPF_SimpleTrader.WPF.State.Navigators
{
    public interface INavigator
    {
        public ViewModelBase CurrentVM { get; set; }

        event Action StateChanged;
    }
}
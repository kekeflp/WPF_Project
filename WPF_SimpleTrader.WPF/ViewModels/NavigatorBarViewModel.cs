using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WPF_SimpleTrader.WPF.State;
using WPF_SimpleTrader.WPF.State.Navigators;
using WPF_SimpleTrader.WPF.ViewModels.Factories;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class NavigatorBarViewModel : ViewModelBase, INavigator
    {
        private readonly ISimpleTraderViewModelFactory _vmAbstractFactory;
        public IRelayCommand<object> UpdateCurrentViewCommand { get; set; }

        private object _currentVM;
        public object CurrentVM
        {
            get { return _currentVM; }
            set { _currentVM = value; OnPropertyChanged(); }
        }

        public NavigatorBarViewModel(ISimpleTraderViewModelFactory vmAbstractFactory)
        {
            _vmAbstractFactory = vmAbstractFactory;
            UpdateCurrentViewCommand = new RelayCommand<object>((v) => UpdateCurrentViewCmd(v));
        }

        private void UpdateCurrentViewCmd(object v)
        {
            if (v is ViewType)
            {
                ViewType viewName = (ViewType)v;
                this.CurrentVM = _vmAbstractFactory.CreateViewModel(viewName);
            }
        }

        // 也可临时 由 private 改为 internal ，方便 UpdateCurrentViewCmd 调用。
        //private void UpdateCurrentViewCmd(object v)
        //{
        //    if (v is ViewType)
        //    {
        //        ViewType viewName = (ViewType)v;

        //        //CreateViewModel(viewName);

        //        //switch (viewName)
        //        //{
        //        //    case ViewType.Home:
        //        //        this.CurrentVM = new HomeViewModel(MajorindexViewModel.LoadMajorindexViewModel(new MajorindexService()));
        //        //        break;
        //        //    case ViewType.Portfolio:
        //        //        this.CurrentVM = new PortfolioViewModel();
        //        //        break;
        //        //    case ViewType.Buy:
        //        //        this.CurrentVM = new BuyViewModel(); ;
        //        //        break;
        //        //    case ViewType.Sell:
        //        //        this.CurrentVM = new SellViewModel();
        //        //        break;
        //        //    default:
        //        //        break;
        //        //}
        //    }
        //}
    }
}
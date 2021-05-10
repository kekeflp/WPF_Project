using System.Windows.Input;
using WPF_SimpleTrader.WPF.Commands;
using WPF_SimpleTrader.WPF.State;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;
using WPF_SimpleTrader.WPF.ViewModels.Factories;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISimpleTraderViewModelFactory _vmAbstractFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentVM => _navigator.CurrentVM;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(IAuthenticator authenticator, INavigator navigator, ISimpleTraderViewModelFactory vmAbstractFactory)
        {
            _navigator = navigator;
            _vmAbstractFactory = vmAbstractFactory;

            // 通过判断是否登录，来确定头部是否显示
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;
            // 使 首页  默认被展示的功能
            // 手动初始化调用委托 来激活首页， 而不是通过Icommand
            // 此处与Controls.NavigationBar的值转换联动 ，如果没有此句，转换方法中的value将为空引用异常。
            //UpdateCurrentViewCommand.Execute(_vmAbstractFactory.CreateViewModel(ViewType.Home));
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _vmAbstractFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentVM));
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }
    }
}
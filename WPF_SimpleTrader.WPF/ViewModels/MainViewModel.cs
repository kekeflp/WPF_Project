using WPF_SimpleTrader.WPF.State;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;
using WPF_SimpleTrader.WPF.ViewModels.Factories;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ISimpleTraderViewModelFactory _vmAbstractFactory;

        // 导航切换(套娃)
        public INavigator NavigatorVM { get; set; }
        public IAuthenticator Authenticator { get; }

        public MainViewModel(IAuthenticator authenticator, INavigator navigator, ISimpleTraderViewModelFactory vmAbstractFactory)
        {
            NavigatorVM = navigator;
            this._vmAbstractFactory = vmAbstractFactory;

            // 通过判断是否登录，来确定头部是否显示 
            Authenticator = authenticator;

            // 使 首页  默认被展示的功能
            // 手动初始化调用委托 来激活首页， 而不是通过Icommand
            // 此处与Controls.NavigationBar的值转换联动 ，如果没有此句，转换方法中的value将为空引用异常。
            //UpdateCurrentViewCommand.Execute(_vmAbstractFactory.CreateViewModel(ViewType.Home));
            NavigatorVM.CurrentVM = _vmAbstractFactory.CreateViewModel(ViewType.Login);
        }
    }
}

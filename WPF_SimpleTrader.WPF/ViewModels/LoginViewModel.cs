using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;
using WPF_SimpleTrader.WPF.ViewModels.Messages;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public IRelayCommand LoginCommand { get; private set; }
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            LoginCommand = new RelayCommand(LoginCmd);

            ErrorMessageViewModel = new MessageViewModel();
        }

        private async void LoginCmd()
        {
            ErrorMessageViewModel.Message = string.Empty;

            try
            {
                await _authenticator.Login(Username, Password);
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                ErrorMessageViewModel.Message = "用户不存在！";
            }
            catch (InvalidPasswordException)
            {
                ErrorMessageViewModel.Message = "密码错误！";
            }
            catch (System.Exception)
            {
                ErrorMessageViewModel.Message = "登录失败,请联系管理员!(如数据库服务链接失败等)!";
            }
        }
    }
}
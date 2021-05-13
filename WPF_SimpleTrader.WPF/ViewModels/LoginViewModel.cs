using Microsoft.Toolkit.Mvvm.Input;
using System;
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
        public IRelayCommand ViewRegisterCommand { get; private set; }

        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _loginNavigator;
        private readonly IRenavigator _registerNavigator;

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginNavigator, IRenavigator registerNavigator)
        {
            _authenticator = authenticator;
            _loginNavigator = loginNavigator;
            _registerNavigator = registerNavigator;
            LoginCommand = new RelayCommand(LoginCmd);
            ViewRegisterCommand = new RelayCommand(ViewRegisterCmd);

            ErrorMessageViewModel = new MessageViewModel();
        }

        /// <summary>
        /// 跳转到注册界面
        /// </summary>
        private void ViewRegisterCmd()
        {
            _registerNavigator.Renavigate();
        }

        private async void LoginCmd()
        {
            ErrorMessageViewModel.Message = string.Empty;

            try
            {
                await _authenticator.Login(Username, Password);
                _loginNavigator.Renavigate();
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
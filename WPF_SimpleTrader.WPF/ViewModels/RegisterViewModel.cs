using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;
using WPF_SimpleTrader.WPF.ViewModels.Messages;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

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

        private string _confirmPassword;

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; OnPropertyChanged(); }
        }

        public MessageViewModel ErrorMessageViewModel { get; private set; }

        public IRelayCommand RegisterCommand { get; private set; }
        public IRelayCommand ViewLoginCommand { get; private set; }
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _loginNavigator;

        public RegisterViewModel(IAuthenticator authenticator, IRenavigator loginNavigator)
        {
            _authenticator = authenticator;
            _loginNavigator = loginNavigator;

            ErrorMessageViewModel = new MessageViewModel();
            RegisterCommand = new RelayCommand(RegisterCmd);
            ViewLoginCommand = new RelayCommand(ViewLoginCmd);
        }

        private void ViewLoginCmd()
        {
            _loginNavigator.Renavigate();
        }

        private async void RegisterCmd()
        {
            ErrorMessageViewModel.Message = string.Empty;
            RegistrationResult registrationResult = await _authenticator.Register(Email, Username, Password, ConfirmPassword);

            switch (registrationResult)
            {
                case RegistrationResult.Succes:
                    // 注册成功后直接跳转到登录界面.
                    _loginNavigator.Renavigate();
                    break;
                case RegistrationResult.PasswordDoNotMatch:
                    ErrorMessageViewModel.Message = "密码与确认密码不一致.";
                    break;
                case RegistrationResult.EmailAlreadyExists:
                    ErrorMessageViewModel.Message = "Email已存在.";
                    break;
                case RegistrationResult.UsernameAlreadyExists:
                    ErrorMessageViewModel.Message = "用户名已存在.";
                    break;
                default:
                    ErrorMessageViewModel.Message = "注册失败.";
                    break;
            }
        }
    }
}

using Microsoft.Toolkit.Mvvm.Input;
using WPF_SimpleTrader.WPF.State.Authenticators;
using WPF_SimpleTrader.WPF.State.Navigators;

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

        public IRelayCommand LoginCommand { get; private set; }
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            LoginCommand = new RelayCommand(LoginCmd);
        }

        private async void LoginCmd()
        {
            bool success = await _authenticator.Login(Username, Password);
            if (success)
            {
                _renavigator.Renavigate();
            }
        }
    }
}

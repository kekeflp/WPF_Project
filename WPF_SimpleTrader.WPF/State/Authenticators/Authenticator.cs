using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;

namespace WPF_SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        private Account _currentAccount;
        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value; 
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            try
            {
                CurrentAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return _authenticationService.Register(email, username, password, confirmPassword);
        }
    }
}

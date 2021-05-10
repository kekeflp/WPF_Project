using System;
using System.Threading.Tasks;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Services.AuthenticationServices;
using WPF_SimpleTrader.WPF.State.Accounts;

namespace WPF_SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            this._authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        //private Account _currentAccount;
        public Account CurrentAccount
        {
            get { return _accountStore.CurrentAccount; }
            set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
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
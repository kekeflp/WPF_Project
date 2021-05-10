using System;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        private Account _currentAccount;

        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set { _currentAccount = value; StateChanged?.Invoke(); }
        }

        public event Action StateChanged;
    }
}
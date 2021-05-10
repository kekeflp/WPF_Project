using System;
using System.Collections.Generic;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.WPF.State.Accounts;

namespace WPF_SimpleTrader.WPF.State.Assets
{
    public class AssetStroe
    {
        private readonly IAccountStore _accountStore;
        public double AccountBalance => _accountStore.CurrentAccount?.Balance ?? 0;
        public IEnumerable<AssetTransaction> AssetTransactions => _accountStore.CurrentAccount?.AssetTransactions ?? new List<AssetTransaction>();

        public event Action StateChanged;

        public AssetStroe(IAccountStore accountStore)
        {
            _accountStore = accountStore;
            _accountStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
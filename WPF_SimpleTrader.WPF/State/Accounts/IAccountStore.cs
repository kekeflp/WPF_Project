using System;
using WPF_SimpleTrader.Domain.Models;

namespace WPF_SimpleTrader.WPF.State.Accounts
{
    /// <summary>
    /// 账户信息-交换变量
    /// </summary>
    public interface IAccountStore
    {
        public Account CurrentAccount { get; set; }

        event Action StateChanged;
    }
}
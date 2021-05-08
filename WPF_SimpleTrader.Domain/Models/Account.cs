using System.Collections.Generic;

namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 账户
    /// </summary>
    public class Account : DomainObject
    {
        public double Balance { get; set; }

        /// <summary>
        /// 账户持有者 ，1:1 关系
        /// </summary>
        public User AccountHolder { get; set; }

        // 1:n 关系
        public ICollection<AssetTransaction> AssetTransactions { get; set; } = new List<AssetTransaction>();
    }
}

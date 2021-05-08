using System;

namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 资产交易
    /// </summary>
    public class AssetTransaction : DomainObject
    {
        public Account Account { get; set; }
        // 是否购买
        public bool IsPurchase { get; set; }
        
        // 1:1 关系
        public Asset Asset { get; set; }
        // 股票份数
        public int Shares { get; set; }
        // 审核日期
        public DateTime DateProcessed { get; set; }
    }
}
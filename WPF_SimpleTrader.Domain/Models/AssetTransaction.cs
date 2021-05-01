using System;

namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 资产交易
    /// </summary>
    public class AssetTransaction
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        // 是否购买
        public bool IsPurchase { get; set; }
        
        // 1:1 关系
        public Stock Stock { get; set; }
        public int Shares { get; set; }
        // 审核日期
        public DateTime DateProcessed { get; set; }
    }
}
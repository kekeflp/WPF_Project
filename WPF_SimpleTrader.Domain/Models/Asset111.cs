namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 资产
    /// </summary>
    public class Asset111 : DomainObject
    {
        // 1:n关系
        public Account Account { get; set; }

        // 股票
        public Asset Stock { get; set; }
        // 股份
        public int Shares { get; set; }
    }
}

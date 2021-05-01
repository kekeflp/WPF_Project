namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 资产
    /// </summary>
    public class Asset
    {
        public int Id { get; set; }
        // 1:n关系
        public Account Account { get; set; }

        // 股票
        public Stock Stock { get; set; }
        // 股份
        public int Shares { get; set; }
    }
}

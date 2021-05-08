namespace WPF_SimpleTrader.Domain.Models
{
    /// <summary>
    /// 股票
    /// </summary>
    public class Asset
    {
        // 象征,标志,符号
        public string Symbol { get; set; }
        // 每股价格
        public double PricePerShare { get; set; }
    }
}
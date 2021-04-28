namespace WPF_SimpleTrader.Domain.Models
{
    public class AssetTransaction
    {
        //+ Id: int
        //+ Account: Account
        //+ IsPurchase: bool
        //+ Stock: Stock
        //+ Shares: int

        public int Id { get; set; }
        public Account Account { get; set; }
        public bool IsPurchase { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }
    }
}

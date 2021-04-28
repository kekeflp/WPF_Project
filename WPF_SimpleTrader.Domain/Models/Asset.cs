namespace WPF_SimpleTrader.Domain.Models
{
    public class Asset
    {
        //+ Id: int
        //+ Account: Account
        //+ Stock: Stock
        //+ Shares: int

        public int Id { get; set; }
        public Account Account { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }
    }
}

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class AssetViewModel
    {
        public string Symbol { get; set; }
        public int Shares { get; set; }

        public AssetViewModel(string symbol, int shares)
        {
            Symbol = symbol;
            Shares = shares;
        }
    }
}
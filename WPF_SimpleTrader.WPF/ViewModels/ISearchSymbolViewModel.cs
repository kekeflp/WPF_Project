namespace WPF_SimpleTrader.WPF.ViewModels
{
    public interface ISearchSymbolViewModel
    {
        string ErrorMessage { set; }
        string ResultOfSymbol { set; }
        double StockPrice { set; }
        string Symbol { get; }
    }
}
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Models.API;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {
        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 这个属性有2个作用，1绑给前端股票名称，2作为框体显示的判断依据，空值时不显示
        /// </summary>
        private string _resultOfsymbol = string.Empty;
        public string ResultOfSymbol
        {
            get { return _resultOfsymbol; }
            set { _resultOfsymbol = value; OnPropertyChanged(); }
        }


        private double _stockPrice;
        public double StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int _shareToBuy;
        public int ShareToBuy
        {
            get { return _shareToBuy; }
            set
            {
                _shareToBuy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice => ShareToBuy * StockPrice;

        private StockResult _stockResultInfo;
        public StockResult StockResultInfo
        {
            get { return _stockResultInfo; }
            set { _stockResultInfo = value; OnPropertyChanged(); }
        }

        private readonly IStockService _stockService;
        private readonly IBuyStockService _buyStockService;
        public IRelayCommand<string> SearchSymbolCommand { get; private set; }
        public IRelayCommand BuyStockCommand { get; private set; }

        public BuyViewModel(IStockService stockService, IBuyStockService buyStockService)
        {
            _stockService = stockService;
            _buyStockService = buyStockService;
            SearchSymbolCommand = new RelayCommand<string>((s) => SearchSymbolCmd(s));
            BuyStockCommand = new RelayCommand(BuyStockCmd);
        }

        private async void BuyStockCmd()
        {
            Account user = await _buyStockService.BuyStock(new Account()
            {
                Id = 1,
                Balance = 500,
                AssetTransactions = new List<AssetTransaction>()
            }, this.Symbol, this.ShareToBuy);
        }

        private async void SearchSymbolCmd(string symbol)
        {
            StockResultInfo = await _stockService.GetStock(symbol.ToUpper());
            this.ResultOfSymbol = StockResultInfo.Symbol;
            this.StockPrice = StockResultInfo.Price;
        }
    }
}

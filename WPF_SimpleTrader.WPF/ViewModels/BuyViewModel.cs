using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows;
using WPF_SimpleTrader.Domain.Exceptions;
using WPF_SimpleTrader.Domain.Models;
using WPF_SimpleTrader.Domain.Models.API;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.WPF.State.Accounts;
using WPF_SimpleTrader.WPF.ViewModels.Messages;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase, ISearchSymbolViewModel
    {
        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value.ToUpper(); OnPropertyChanged(); }
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

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }
        public MessageViewModel StatusMessageViewModel { get; }

        public double TotalPrice => ShareToBuy * StockPrice;

        private StockResult _stockResultInfo;

        public StockResult StockResultInfo
        {
            get { return _stockResultInfo; }
            set { _stockResultInfo = value; OnPropertyChanged(); }
        }

        private readonly IStockService _stockService;
        private readonly IBuyStockService _buyStockService;
        private readonly IAccountStore _accountStore;
        public IRelayCommand<string> SearchSymbolCommand { get; private set; }
        public IRelayCommand BuyStockCommand { get; private set; }

        public BuyViewModel(IStockService stockService, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            _stockService = stockService;
            _buyStockService = buyStockService;
            _accountStore = accountStore;

            SearchSymbolCommand = new RelayCommand<string>((s) => SearchSymbolCmd(s));
            BuyStockCommand = new RelayCommand(BuyStockCmd);

            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();
        }

        private async void BuyStockCmd()
        {
            // 虚构的用户
            //Account user = await _buyStockService.BuyStock(new Account()
            //{
            //    Id = 1,
            //    Balance = 500,
            //    AssetTransactions = new List<AssetTransaction>()
            //}, this.Symbol, this.ShareToBuy);

            StatusMessageViewModel.Message = string.Empty;
            ErrorMessageViewModel.Message = string.Empty;
            // 需要带入当前登录的用户信息
            try
            {
                Account account = await _buyStockService.BuyStock(_accountStore.CurrentAccount, this.Symbol, this.ShareToBuy);
                _accountStore.CurrentAccount = account;

                StatusMessageViewModel.Message = $"成功购买 {ShareToBuy} 股 {Symbol} 的股票.";
            }
            catch (InsufficientFundsException)
            {
                ErrorMessageViewModel.Message = "账户资金不足，请充值！";
            }
            catch (Exception)
            {
                ErrorMessageViewModel.Message = "交易失败！";
            }
        }

        private async void SearchSymbolCmd(string symbol)
        {
            StatusMessageViewModel.Message = string.Empty;
            ErrorMessageViewModel.Message = string.Empty;

            try
            {
                StockResultInfo = await _stockService.GetStock(symbol.ToUpper());
                this.ResultOfSymbol = StockResultInfo.Symbol;
                this.StockPrice = StockResultInfo.Price;
            }
            catch (InvalidSymbolException)
            {
                ErrorMessageViewModel.Message = "股票不存在！";
            }
            catch (Exception)
            {
                ErrorMessageViewModel.Message = "获取股票信息失败！";
            }
        }
    }
}
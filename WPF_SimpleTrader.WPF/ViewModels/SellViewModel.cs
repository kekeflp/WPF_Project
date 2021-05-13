using SimpleTrader.WPF.Commands;
using System.Windows.Input;
using WPF_SimpleTrader.Domain.Models.API;
using WPF_SimpleTrader.Domain.Services;
using WPF_SimpleTrader.Domain.Services.TransactionServices;
using WPF_SimpleTrader.WPF.Commands;
using WPF_SimpleTrader.WPF.State.Accounts;
using WPF_SimpleTrader.WPF.State.Assets;
using WPF_SimpleTrader.WPF.ViewModels.Messages;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class SellViewModel : ViewModelBase, ISearchSymbolViewModel
    {
        public AssetListingViewModel AssetListingVM { get; set; }

        private AssetViewModel _selectedAsset;
        public AssetViewModel SelectedAsset
        {
            get { return _selectedAsset; }
            set { _selectedAsset = value; OnPropertyChanged(); }
        }

        private StockResult _stockResultInfo;
        public StockResult StockResultInfo
        {
            get { return _stockResultInfo; }
            set { _stockResultInfo = value; OnPropertyChanged(); }
        }
        public string Symbol => SelectedAsset?.Symbol;

        private string _resultOfSymbol;
        public string ResultOfSymbol
        {
            get { return _resultOfSymbol; }
            set
            {
                _resultOfSymbol = value;
                OnPropertyChanged();
            }
        }

        private double _stockPrice;
        public double StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int _sharesToSell;
        public int SharesToSell
        {
            get { return _sharesToSell; }
            set
            {
                _sharesToSell = value;
                OnPropertyChanged(nameof(SharesToSell));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice => SharesToSell * StockPrice;

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }

        public MessageViewModel StatusMessageViewModel { get; }

        public string StatusMessage { set => StatusMessageViewModel.Message = value; }

        public ICommand SearchSymbolCommand { get; private set; }
        public ICommand SellStockCommand { get; private set; }

        public SellViewModel(AssetStroe assetStroe, IStockService stockService, IAccountStore accountStore, ISellStockService sellStockService)
        {

            AssetListingVM = new AssetListingViewModel(assetStroe);
            SearchSymbolCommand = new SearchSymbolCommand(this, stockService);
            SellStockCommand = new SellStockCommand(this, sellStockService, accountStore);
            ErrorMessageViewModel = new MessageViewModel();
            StatusMessageViewModel = new MessageViewModel();
        }
    }
}
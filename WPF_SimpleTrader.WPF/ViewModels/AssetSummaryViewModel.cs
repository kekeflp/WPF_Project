using System.Linq;
using WPF_SimpleTrader.WPF.State.Assets;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStroe _assetStroe;
        public double AccountBalance => _assetStroe.AccountBalance;

        public AssetListingViewModel AssetListingVM { get; }

        public AssetSummaryViewModel(AssetStroe assetStroe)
        {
            _assetStroe = assetStroe;
            AssetListingVM = new AssetListingViewModel(assetStroe, filter => filter.Take(3));
            _assetStroe.StateChanged += AssetStroe_StateChanged;
        }

        private void AssetStroe_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
        }
    }
}
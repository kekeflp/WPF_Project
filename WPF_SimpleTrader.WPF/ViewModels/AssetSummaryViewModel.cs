using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_SimpleTrader.WPF.State.Assets;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        private readonly AssetStroe _assetStroe;
        public double AccountBalance => _assetStroe.AccountBalance;

        public readonly ObservableCollection<AssetViewModel> _topAssetVMs;
        public IEnumerable<AssetViewModel> TopAssetVMs => _topAssetVMs;

        public AssetSummaryViewModel(AssetStroe assetStroe)
        {
            _assetStroe = assetStroe;
            _topAssetVMs = new ObservableCollection<AssetViewModel>();
            _assetStroe.StateChanged += AssetStroe_StateChanged;
            ResetAssets();
        }

        private void AssetStroe_StateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetAssets();
        }

        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStroe.AssetTransactions
                .GroupBy(t => t.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares)))
                .Where(a => a.Shares > 0)
                .OrderByDescending(o => o.Shares)
                .Take(3);

            _topAssetVMs.Clear();
            foreach (AssetViewModel viewModel in assetViewModels)
            {
                _topAssetVMs.Add(viewModel);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_SimpleTrader.WPF.State.Assets;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class AssetListingViewModel : ViewModelBase
    {
        private readonly AssetStroe _assetStroe;
        private readonly Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> _filterAssets;
        public readonly ObservableCollection<AssetViewModel> _assetVMs;
        public IEnumerable<AssetViewModel> AssetVMs => _assetVMs;

        // filter => filter, 以为着什么也不干, 原封不动的丢出去
        public AssetListingViewModel(AssetStroe assetStroe) : this(assetStroe, filter => filter)
        {

        }

        public AssetListingViewModel(AssetStroe assetStroe, Func<IEnumerable<AssetViewModel>, IEnumerable<AssetViewModel>> filterAssets)
        {
            _assetStroe = assetStroe;
            _filterAssets = filterAssets;
            _assetVMs = new ObservableCollection<AssetViewModel>();
            _assetStroe.StateChanged += AssetStroe_StateChanged;
            ResetAssets();
        }

        private void AssetStroe_StateChanged()
        {
            ResetAssets();
        }

        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStroe.AssetTransactions
                .GroupBy(t => t.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares)))
                .Where(a => a.Shares > 0)
                .OrderByDescending(o => o.Shares);

            // 重点 回调
            assetViewModels = _filterAssets(assetViewModels);

            _assetVMs.Clear();
            foreach (AssetViewModel viewModel in assetViewModels)
            {
                _assetVMs.Add(viewModel);
            }
        }
    }
}

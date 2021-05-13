using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_SimpleTrader.WPF.State.Assets;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class PortfolioViewModel : ViewModelBase
    {
        public AssetListingViewModel AssetListingVM { get; }
        public PortfolioViewModel(AssetStroe assetStroe)
        {
            AssetListingVM = new AssetListingViewModel(assetStroe);
        }
    }
} 
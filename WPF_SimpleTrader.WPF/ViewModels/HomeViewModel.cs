namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public AssetSummaryViewModel AssetSummaryViewModel { get; }
        public MajorindexViewModel MajorindexVM { get; }

        public HomeViewModel(MajorindexViewModel majorindexViewModel, AssetSummaryViewModel assetSummaryViewModel)
        {
            MajorindexVM = majorindexViewModel;
            AssetSummaryViewModel = assetSummaryViewModel;
        }
    }
}
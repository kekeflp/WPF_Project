using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace WPF_SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public MajorindexViewModel MajorindexVM { get; set; }

        public HomeViewModel(MajorindexViewModel majorindexViewModel)
        {
            MajorindexVM = majorindexViewModel;
        }
    }
}

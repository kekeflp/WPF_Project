using WPF_CoronavirusChart.Services;
using WPF_CoronavirusChart.ViewModels;
using System.Windows.Controls;

namespace WPF_CoronavirusChart
{
    /// <summary>
    /// CountryChartView.xaml 的交互逻辑
    /// </summary>
    public partial class CountryChartView : UserControl
    {
        public CountryChartViewModel _countryChartViewModel { get; set; }
        public CountryChartView()
        {
            InitializeComponent();
            _countryChartViewModel = CountryChartViewModel.LoadViewModel(new CoronavirusService());
            DataContext = _countryChartViewModel;
        }
    }
}

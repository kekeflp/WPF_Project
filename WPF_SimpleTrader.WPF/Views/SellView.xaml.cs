using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_SimpleTrader.WPF.Views
{
    /// <summary>
    /// SellView.xaml 的交互逻辑
    /// </summary>
    public partial class SellView : UserControl
    {
        public SellView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SelectedAssetChangedCommandProperty =
         DependencyProperty.Register("SelectedAssetChangedCommand", typeof(ICommand), typeof(SellView),
             new PropertyMetadata(null));

        public ICommand SelectedAssetChangedCommand
        {
            get { return (ICommand)GetValue(SelectedAssetChangedCommandProperty); }
            set { SetValue(SelectedAssetChangedCommandProperty, value); }
        }

        private void cbAssets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAssets.SelectedItem != null)
            {
                SelectedAssetChangedCommand?.Execute(null);
            }
        }
    }
}
using System.Windows;
using WPF_Resume.ViewModels;
using WPF_Resume.Views;
    
namespace WPF_Resume
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}

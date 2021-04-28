using System.Windows.Controls;

namespace WPF_ExpenseIt
{
    /// <summary>
    /// ExpenseItHome.xaml 的交互逻辑
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ExpenseReportPage erp = new ExpenseReportPage(this.peopleListBox.SelectedItem);
            this.NavigationService.Navigate(erp);
        }
    }
}

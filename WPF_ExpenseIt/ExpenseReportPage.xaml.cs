using System.Windows.Controls;

namespace WPF_ExpenseIt
{
    /// <summary>
    /// ExpenseReportPage.xaml 的交互逻辑
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();
        }

        // Custom constructor to pass expense report data
        public ExpenseReportPage(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }
    }
}

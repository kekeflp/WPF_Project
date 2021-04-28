using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DataGridSQLExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        AdventureWorksLT2019Entities dataEntities = new AdventureWorksLT2019Entities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = dataEntities.Product.Where(p => p.Color == "Red").OrderBy(p => p.ListPrice).ToList();

            this.MyDataGrid.ItemsSource = query;

        }
    }
}

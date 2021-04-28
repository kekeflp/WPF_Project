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

namespace WPF_TunnelRouteEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int eventCounter = 0;

        private void SomeKeyPressed(object sender, KeyEventArgs e)
        {
            eventCounter++;
            var message = "#" + eventCounter.ToString() + "\r\n" +
                          " Sender:  " + sender.ToString() + "\r\n" +
                          " Source:  " + e.Source + "\r\n" +
                          " Original Source:  " + e.OriginalSource + "\r\n" +
                          " Event:  " + e.RoutedEvent;
            LstMessage.Items.Add(message);
            e.Handled = (bool)ChkHandle.IsChecked;
        }

        private void CmdClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            LstMessage.Items.Clear();
        }
    }
}

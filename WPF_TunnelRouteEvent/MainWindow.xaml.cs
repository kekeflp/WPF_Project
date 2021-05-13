using System.Windows;
using System.Windows.Input;

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
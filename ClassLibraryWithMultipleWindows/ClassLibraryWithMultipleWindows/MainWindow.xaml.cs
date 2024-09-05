using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassLibraryWithMultipleWindows
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

        private void BtnAddInfo_Click(object sender, RoutedEventArgs e)
        {
            AddInfo addInformation = new AddInfo();
            addInformation.Show();
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
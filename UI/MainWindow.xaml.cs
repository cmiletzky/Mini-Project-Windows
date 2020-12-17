using BlApi;
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

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static IBL bl;
        public static bool isManager = false;
        public MainWindow()
        {
            InitializeComponent();
            if (isManager != true)
            {
                main_contect.Visibility = Visibility.Hidden;
            }
            else
            {
                main_contect.Visibility = Visibility.Visible;
            }

            bl = BlFactory.GetBl();

           bus_list.ItemsSource = bl.presentAllBus();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EnterWin enterWin = new EnterWin();
            enterWin.ShowDialog();
        }
    }
}


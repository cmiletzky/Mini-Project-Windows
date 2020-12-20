using BlApi;
using PIGui;
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

namespace PIGui
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IBL bl;
      public static  string arrMes = "";
       public static bool canDrive = false;
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
            stops_list.ItemsSource = bl.presentAllStation();
            line_list.ItemsSource = bl.presentAllLines();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EnterWin enterWin = new EnterWin();
            enterWin.ShowDialog();
        }

        private void Start_driving(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            BO.Bus busToTrip = (BO.Bus)cmd.DataContext;
            
            
            canDrive = bl.canDrive(busToTrip, ref arrMes);
            if (canDrive)
            {
                StartTrip startTrip = new StartTrip(busToTrip, (Button)sender);
                startTrip.ShowDialog();
            }
            else
            {
                MessageBox.Show(arrMes);
            }
        }

        private void Refueling(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            BO.Bus busToRrfuell = (BO.Bus)cmd.DataContext;
            if (bl.Refuell(busToRrfuell, ref arrMes)==false)
            {
                MessageBox.Show(arrMes);
            }  
        }

        private void bus_list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.Bus busToDetail = (BO.Bus)bus_list.SelectedItem;
            BusDetails detailDialog = new BusDetails(busToDetail);
            detailDialog.Show();
        }

        private void stops_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station busToDetail = (BO.Station)stops_list.Items[stops_list.SelectedIndex];
            code_stop.Text = busToDetail.Code.ToString();
        }
    }
}


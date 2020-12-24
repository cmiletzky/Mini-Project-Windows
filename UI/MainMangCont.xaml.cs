using BL.BO;
using BO;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for MainMangCont.xaml
    /// </summary>
    public partial class MainMangCont : Page
    {
        public static bool canDrive = false;

        public MainMangCont()
        {

            InitializeComponent();

            bus_list.ItemsSource = MainWindow.bl.presentAllBus(true);
            stops_list.ItemsSource = MainWindow.bl.presentAllStation();
            line_list.ItemsSource = MainWindow.bl.presentAllLines();

        }


        private void Lines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.LineBus lineToDetail = (BO.LineBus)line_list.SelectedItem;
            if (lineToDetail != null)
            {
                LineDetail detailDialog = new LineDetail(lineToDetail);
                detailDialog.Show();
            }

        }

        private void Start_driving(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            Bus busToTrip = (Bus)cmd.DataContext;


            canDrive = MainWindow.bl.canDrive(busToTrip, ref MainWindow.arrMes);
            if (canDrive)
            {
                StartTrip startTrip = new StartTrip(busToTrip, (Button)sender);
                startTrip.ShowDialog();
            }
            else
            {
                MessageBox.Show(MainWindow.arrMes);
            }
        }

        private void Refueling(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            Bus busToRrfuell = (Bus)cmd.DataContext;
            if (MainWindow.bl.Refuell(busToRrfuell, ref MainWindow.arrMes) == false)
            {
                MessageBox.Show(MainWindow.arrMes);
            }
        }

        private void bus_list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bus busToDetail = (Bus)bus_list.SelectedItem;
            if (busToDetail != null)
            {
                BusDetails detailDialog = new BusDetails(busToDetail);
                detailDialog.Show();
            }

        }

        private void stops_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station busToDetail = (BO.Station)stops_list.Items[stops_list.SelectedIndex];
            code_stop.Text = busToDetail.Code.ToString();
        }

        private void add_bus_Click(object sender, RoutedEventArgs e)
        {
            NewBus newBus = new NewBus(ref bus_list);
            newBus.Show();
        }

        private void update_bus_Click(object sender, RoutedEventArgs e)
        {
            if (bus_list.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the bus you want to update");
            }
            else 
            {
                Bus busToUpdate = (Bus)bus_list.Items[bus_list.SelectedIndex];
                new UpdateBus(busToUpdate).Show();
                //bus_list.Items.Refresh();
            }
        }

        private void remove_bus_Click(object sender, RoutedEventArgs e)
        {
            if (bus_list.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the bus you want to remove");
            }
            else if (MessageBox.Show("Are you sure you want to delete the bus?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Bus busToRemove = (Bus)bus_list.Items[bus_list.SelectedIndex];
                MainWindow.bl.RemoveBus(busToRemove);
                bus_list.ItemsSource = MainWindow.bl.presentAllBus(false);
                //bus_list.Items.Refresh();
            }

        }

        private void line_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            LineBus n = (LineBus)line_list.Items[line_list.SelectedIndex];
            stop_of_line.ItemsSource = n.StationList;
            stop_of_line.DisplayMemberPath = "Id";
        }
    }
}

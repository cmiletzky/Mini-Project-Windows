using BL.BO;
using BO;
using PL.line;
using PL.stops;
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
            stop_list.ItemsSource = MainWindow.bl.presentAllStation(true);
            line_list.ItemsSource = MainWindow.bl.presentAllLines(true);
            stop_lime_list.ItemsSource = MainWindow.bl.presentStopsLine();

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
                new UpdateBus(busToUpdate, ref bus_list).Show();
                //bus_list.Items.Refresh();
            }
        }

        private void remove_bus_Click(object sender, RoutedEventArgs e)
        {
            if (bus_list.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the bus you want to remove");
            }
            else
            {
                Bus busToRemove = (Bus)bus_list.Items[bus_list.SelectedIndex];
                if (MessageBox.Show("Are you sure you want to delete the bus " + busToRemove.Id + " ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    MainWindow.bl.RemoveBus(busToRemove);
                    bus_list.ItemsSource = MainWindow.bl.presentAllBus(false);
                }
            }

        }

        private void line_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (line_list.SelectedIndex != -1)
            {
                LineBus line = (LineBus)line_list.Items[line_list.SelectedIndex];

                list_stop_of_line.ItemsSource = line.Stops;

            }
            else
            {
                list_stop_of_line.ItemsSource = null;
            }

        }

        private void add_new_station(object sender, RoutedEventArgs e)
        {

        }

        private void update_station(object sender, RoutedEventArgs e)
        {

        }

        private void add_line_Click(object sender, RoutedEventArgs e)
        {
            new NewLine(ref line_list).ShowDialog();
        }

        private void update_line_Click(object sender, RoutedEventArgs e)
        {

            if (line_list.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the line you want to remove");
            }
            else
            {
                LineBus lineToUpdate = (LineBus)line_list.SelectedValue;
                new UpdateLine(lineToUpdate, ref line_list).ShowDialog();
            }
        }

        private void remove_line_Click(object sender, RoutedEventArgs e)
        {
            if (line_list.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the line you want to remove");
            }
            else
            {
                LineBus lineToRemove = (LineBus)line_list.SelectedValue;
                if (MessageBox.Show("Are you sure you want to delete the line " + lineToRemove.LineNum + " ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    MainWindow.bl.RemoveLine(lineToRemove);
                    //TODOלטפל בעת מחיקת קו למחוק תחנות קו 
                    stop_lime_list.ItemsSource = MainWindow.bl.presentStopsLine();
                    line_list.ItemsSource = MainWindow.bl.presentAllLines(false);
                  
                }
            }
        }

        private void remove_stop_line_Click(object sender, RoutedEventArgs e)
        {

        }

        private void update_stop_line_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_stop_line_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stop_lime_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stop_lime_list.SelectedIndex!=-1)
            {
                BO.Station a = (BO.Station)stop_lime_list.SelectedValue;
                stop_num.Text = a.Code.ToString();
                stop_name.Text = a.Name;
                stop_lo.Text = a.Longtitude.ToString();
                stop_la.Text = a.Latitude.ToString();

                stops_before.ItemsSource = MainWindow.bl.GetAdjacentStatisionBefore(a.Code);
                stops_after.ItemsSource = MainWindow.bl.GetAdjacentStatisionAfter(a.Code);

            }

        }

        private void stops_before_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void stops_after_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void edit_a_s_Click(object sender, RoutedEventArgs e)
        {
            Button cdn = (Button)sender;
            AdjacentStatision adjacentStatision = (AdjacentStatision)cdn.DataContext;
            new EditAdjacentStatision(adjacentStatision, int.Parse(stop_num.Text)).ShowDialog();
            stop_lime_list.SelectedIndex = -1;
            stops_before.ItemsSource = null;
            stops_after.ItemsSource = null;
                
        }
    }

 }
   




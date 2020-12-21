using BL.BO;
using BlApi;
using PIGui;
using PL;
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
            Auth.user = new BO.User();
            
            RefreshMenu();
            //if (Auth.user.UserName==null)
            //{
            //    EnterWin enterWin = new EnterWin();
            //    enterWin.ShowDialog();
            //}

            if (Auth.user.Admin==false|| Auth.user == null)
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

        private void Login_Click(object sender, RoutedEventArgs e)
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

        private void logout_menu(object sender, RoutedEventArgs e)
        {
            Auth.user = null;
            main_contect.Visibility = Visibility.Hidden;
            RefreshMenu();


            // main_contect.Visibility = Visibility.Hidden;
        }

        

        private void Lines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.Line lineToDetail = (BO.Line)line_list.SelectedItem;
            LineDetail detailDialog = new LineDetail(lineToDetail);
            detailDialog.Show();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Show();
        }

    

       public  void RefreshMenu()
        {
            if (Auth.user == null||Auth.user.UserName == null)
            {
                menu_account.Visibility = Visibility.Collapsed;
                menu_logout.Visibility = Visibility.Collapsed;
                menu_login.Visibility = Visibility.Visible; 
            }
            else
            {
                menu_account.Visibility = Visibility.Visible;
                menu_logout.Visibility = Visibility.Visible;
                menu_login.Visibility = Visibility.Collapsed;
            }
            
            
        }
    }
}


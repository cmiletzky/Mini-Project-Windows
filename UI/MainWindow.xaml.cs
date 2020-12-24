using BL.BO;
using BlApi;
using PL;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IBL bl;
        public static bool isRun = true;
        public static string arrMes = "";
        public static bool canDrive = false;
       
        public MainWindow()
        {
           
            bl = BlFactory.GetBl();
            InitializeComponent();
            Auth.user = new BO.User();
            RefreshMenu();

            //if (Auth.user.Admin == false || Auth.user == null)
            //{
            //    manager_cont.Visibility = Visibility.Hidden;
             
            //}
            //else
            //{
            //    manager_cont.Visibility = Visibility.Collapsed;
            //}
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            EnterWin enterWin = new EnterWin();
            enterWin.ShowDialog();
        }



        private void logout_menu(object sender, RoutedEventArgs e)
        {
            Auth.user = null;
            Main.Visibility = Visibility.Collapsed;
            RefreshMenu();


            // main_contect.Visibility = Visibility.Hidden;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            account.Show();
        }

        public void RefreshMenu()
        {
            if (Auth.user == null || Auth.user.UserName == null)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new EnterWin().ShowDialog();
        }
    }
}


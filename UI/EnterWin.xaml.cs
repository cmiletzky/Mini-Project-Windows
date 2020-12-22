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
using System.Windows.Shapes;
using BO;
using BlApi;
using BL.BO;

namespace PL
{
    /// <summary>
    /// Interaction logic for EnterWin.xaml
    /// </summary>
    public partial class EnterWin : Window
    {
        public static IBL bl;
        public EnterWin()
        {
            InitializeComponent();
            bl = BlFactory.GetBl();
        }
        private void login_maneger_Click(object sender, RoutedEventArgs e)
        {
            
            if (bl.isUserMang(user_manager.Text, pas_manager.Text,true))
            {
                Auth auth = new Auth(user_manager.Text, pas_manager.Text,true);
               ((MainWindow)Application.Current.MainWindow).manager_cont.Visibility = Visibility.Visible;
                ((MainWindow)Application.Current.MainWindow).RefreshMenu();
                Close();
            }
            else
            {
                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBox.Show("Incorrect login information\nAre you interested in contacting support?", "Warning", buttons, MessageBoxImage.Error);
            }
        }
    }
}

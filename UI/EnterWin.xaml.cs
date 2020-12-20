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

namespace PIGui
{
    /// <summary>
    /// Interaction logic for EnterWin.xaml
    /// </summary>
    public partial class EnterWin : Window
    {
        public EnterWin()
        {
            InitializeComponent();
        }
        private void login_maneger_Click(object sender, RoutedEventArgs e)
        {
            
            if (user_manager.Text == "1" && pas_manager.Text == "1")
            {
                MainWindow.isManager = true;
                ((MainWindow)Application.Current.MainWindow).main_contect.Visibility = Visibility.Visible;
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

using BL.BO;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public Account()
        {
            InitializeComponent();
            if (Auth.user!=null)
            {
                name.Text = Auth.user.UserName;
                if (Auth.user.Admin==true)
                {
                    is_mang.Text = "מנהל";
                }
            }
           
        }

        private void change_pass_Click(object sender, RoutedEventArgs e)
        {
            change.Visibility = Visibility.Visible;
           
        }

        private void sava_pass_Click(object sender, RoutedEventArgs e)
        {
            //TODO לטפל
            MainWindow.bl.ChangePass(Auth.user, pass.Text);
            Auth.user.Password = pass.Text;

            change.Visibility = Visibility.Collapsed;
        }
    }
}

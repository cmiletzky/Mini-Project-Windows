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

        private void Start_driving(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            var p = cmd.Parent as Grid;
            string id = p.Children[0].ToString();
            //bool canDrive = bl.canDrive();

            //Button cmd = (Button)sender;
            //var p = cmd.Parent as Grid;
            //if (cmd.DataContext is BO.Bus)
            //{

            //    BO.Bus deleteme = (BO.Bus)cmd.DataContext;
            //    string bus_id = deleteme.Id.ToString();
            //    // chck condition weather the bus can exit to driving
            //    if (deleteme.InTreamant)
            //    {
            //        MessageBox.Show("bus " + bus_id + " busy in treatment");
            //    }
            //    else if (deleteme.InRefule)
            //    {
            //        MessageBox.Show("bus " + bus_id + " busy in refule");
            //    }
            //    else if (deleteme.InDriving)
            //    {
            //        MessageBox.Show("bus number " + deleteme.Id + " in driving now");
            //    }
            //    // if all conditon alow it, sanding the bus
            //    else
            //    {
            //        InputKm inputDialog = new InputKm(deleteme, (Button)sender);

            //        inputDialog.Show();
            //    }

            //}
        }
    }
}


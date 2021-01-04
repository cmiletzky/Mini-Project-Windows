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

namespace PL.stops
{
    /// <summary>
    /// Interaction logic for UpdateStop.xaml
    /// </summary>
    public partial class UpdateStop : Window
    {
        int oldNum;
        public UpdateStop(BO.Station stopTo)
        {
            InitializeComponent();
            oldNum = stopTo.Code;
            stop_name.Text = stopTo.Name;
            stop_num.Text = stopTo.Code.ToString();

            stop_la.Text = stopTo.Latitude.ToString();
            stop_lo.Text = stopTo.Longtitude.ToString();

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bl.updateStop(new BO.Station(int.Parse(stop_num.Text), stop_name.Text, double.Parse(stop_lo.Text), double.Parse(stop_la.Text)),oldNum);

            }
            catch (Exception w)
            {

                MessageBox.Show(w.Message);
            }
            Close();
        }
    }
}

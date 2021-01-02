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
using System.Windows.Shapes;

namespace PL.stops
{
    /// <summary>
    /// Interaction logic for EditAdjacentStatision.xaml
    /// </summary>
    public partial class EditAdjacentStatision : Window
    {
        public EditAdjacentStatision(AdjacentStatision toEdit, int stop)
        {
            InitializeComponent();
            stop1_name.Text = toEdit.StationName1;
            stop2_name.Text = toEdit.StationName2;

            stop1_num.Text = toEdit.StationNum1.ToString();
            stop2_num.Text = toEdit.StationNum2.ToString();

            dis.Text = toEdit.Distance.ToString();
            string t = toEdit.Time.ToString().Replace(":", "");
            time_h.Text = t.Substring(0, 2);
            time_m.Text = t.Substring(2, 2);
            time_s.Text = t.Substring(4, 2);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan times = new TimeSpan(int.Parse(time_h.Text), int.Parse(time_m.Text), int.Parse(time_s.Text));
            MainWindow.bl.EditAdjacentStatision(int.Parse(stop1_num.Text), int.Parse(stop2_num.Text), double.Parse(dis.Text), times);
          //  MainWindow.bl.GetAdjacentStatisionAfter()
            Close();
        }
    }
}

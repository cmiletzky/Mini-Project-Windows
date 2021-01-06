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
       Station stopToEdit;
         Station stopMain;
        int situation;
        public EditAdjacentStatision(Station toEdit,Station main, int Situation)
        {
            situation = Situation;
            stopToEdit = toEdit;
            stopMain = main;
            InitializeComponent();
            stop1_name.Text = StopMain.Name;
            stop2_name.Text = StopToEdit.Name;

            stop1_num.Text = StopMain.Code.ToString();
            stop2_num.Text = StopToEdit.Code.ToString();

            dis.Text = StopToEdit.DistanceFromPrivios.ToString();
            string t = StopToEdit.TimeFromPrivios.ToString().Replace(":", "");
            time_h.Text = t.Substring(0, 2);
            time_m.Text = t.Substring(2, 2);
            time_s.Text = t.Substring(4, 2);
        }

        public Station StopToEdit { get => stopToEdit; set => stopToEdit = value; }
        public Station StopMain { get => stopMain; set => stopMain = value; }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan times = new TimeSpan(int.Parse(time_h.Text), int.Parse(time_m.Text), int.Parse(time_s.Text));
            if (situation ==0)
            {
                MainWindow.bl.EditAdjacentStatision(int.Parse(stop2_num.Text), int.Parse(stop1_num.Text), double.Parse(dis.Text), times);
            }
            else
            {
                MainWindow.bl.EditAdjacentStatision(int.Parse(stop1_num.Text), int.Parse(stop2_num.Text), double.Parse(dis.Text), times);
            }

            //  MainWindow.bl.GetAdjacentStatisionAfter()
            Close();
        }
    }
}

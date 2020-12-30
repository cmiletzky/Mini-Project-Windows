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

namespace PL.line
{
    /// <summary>
    /// Interaction logic for EditDataStopOfLine.xaml
    /// </summary>
    public partial class EditDataStopOfLine : Window
    {
        BO.Station stop1;
        BO.Station stop2;
        public EditDataStopOfLine(BO.Station stop1 , BO.Station stop2)
        {
            InitializeComponent();

            this.stop1 = stop1;
            this.stop2 = stop2;


            name_of_1.Text = stop1.Name;
            num_of_1.Text = stop1.Code.ToString();
            
            name_of_2.Text = stop2.Name;
            num_of_2.Text = stop2.Code.ToString();

            dis.Text = stop2.DistanceFromPrivios.ToString();
            time.Text = stop2.TimeFromPrivios.ToString();



        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string a = time.Text.Replace(":", "");

            TimeSpan timeSpan = new TimeSpan(int.Parse(a.Substring(0, 2)), int.Parse(a.Substring(2, 2)), int.Parse(a.Substring(4, 2)));
            MainWindow.bl.EditAdjacentStatision(stop1.Code, stop2.Code, double.Parse(dis.Text), timeSpan);
            Close();
        }
    }
}

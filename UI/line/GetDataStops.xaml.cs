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
    /// Interaction logic for GetDataStops.xaml
    /// </summary>
    public partial class GetDataStops : Window
    {
        BO.Station preStop;
        BO.Station newStop;
        BO.Station nextStop;
        public GetDataStops(BO.Station preStop , BO.Station newStop, BO.Station nextStop)
        {
            InitializeComponent();
            this.preStop = preStop;
            this.newStop = newStop;
            this.nextStop = nextStop;
            name_of_pre.Text = preStop.Name;
            num_of_pre.Text = preStop.Code.ToString();

            name_of_new.Text = newStop.Name;
            num_of_new.Text = newStop.Code.ToString();
            
            name_of_next.Text = nextStop.Name;
            num_of_next.Text = nextStop.Code.ToString();
        }

        public GetDataStops(BO.Station firstStop,BO.Station newStop)
        {
            this.newStop = newStop;
            this.newStop = firstStop;
          //  pre.IsEnabled = false;
            name_of_new.Text = newStop.Name;
            num_of_new.Text = newStop.Code.ToString();

            name_of_next.Text = firstStop.Name;
            num_of_next.Text = firstStop.Code.ToString();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timeNew = new TimeSpan(int.Parse(time_h.Text), int.Parse(time_m.Text), int.Parse(time_s.Text));
            TimeSpan timeNext = new TimeSpan(int.Parse(time_h_next.Text), int.Parse(time_m_next.Text), int.Parse(time_s_next.Text));
            MainWindow.bl.AddAdjacentStatision(preStop.Code, newStop.Code, dis.Text, timeNew);
            MainWindow.bl.AddAdjacentStatision(newStop.Code, nextStop.Code, dis_next.Text, timeNext);
            Close();
        }
    }
}

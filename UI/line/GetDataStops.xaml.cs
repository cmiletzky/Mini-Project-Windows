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
            InitializeComponent();
            this.newStop = newStop;
            this.nextStop = firstStop;
            pre.Visibility = Visibility.Collapsed;
            name_of_new.Text = newStop.Name;
            num_of_new.Text = newStop.Code.ToString();
            data_pre.Visibility = Visibility.Hidden;

            name_of_next.Text = firstStop.Name;
            num_of_next.Text = firstStop.Code.ToString();
        } 
        public GetDataStops(BO.Station preStop,BO.Station newStop,int a,int b)
        {
            InitializeComponent();
            this.newStop = newStop;
            this.preStop = preStop;
            this.nextStop = null;
            next.Visibility = Visibility.Collapsed;
            name_of_new.Text = newStop.Name;
            num_of_new.Text = newStop.Code.ToString();
          

            name_of_pre.Text = preStop.Name;
            num_of_pre.Text = preStop.Code.ToString();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (preStop == null)
            {
                TimeSpan timeNext1 = new TimeSpan(int.Parse(time_h_next.Text), int.Parse(time_m_next.Text), int.Parse(time_s_next.Text));
                MainWindow.bl.AddAdjacentStatision(newStop.Code, nextStop.Code, dis_next.Text, timeNext1);

            }
            else if (nextStop==null)
            {
                TimeSpan timeNext2 = new TimeSpan(int.Parse(time_h.Text), int.Parse(time_m.Text), int.Parse(time_s.Text));
                MainWindow.bl.AddAdjacentStatision(preStop.Code, newStop.Code, dis.Text, timeNext2);
            }
            else
            {
                TimeSpan timeNew = new TimeSpan(int.Parse(time_h.Text), int.Parse(time_m.Text), int.Parse(time_s.Text));
                TimeSpan timeNext = new TimeSpan(int.Parse(time_h_next.Text), int.Parse(time_m_next.Text), int.Parse(time_s_next.Text));
                MainWindow.bl.AddAdjacentStatision(preStop.Code, newStop.Code, dis.Text, timeNew);
                MainWindow.bl.AddAdjacentStatision(newStop.Code, nextStop.Code, dis_next.Text, timeNext);
            }

            Close();
        }
    }
}

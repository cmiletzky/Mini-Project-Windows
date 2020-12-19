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
    /// Interaction logic for BusDetails.xaml
    /// </summary>
    public partial class BusDetails : Window
    {
        public BusDetails(BO.Bus bus)
        {
          //  BO.Bus busIndexSelcted = ((MainWindow)Application.Current.MainWindow).bus_list[((MainWindow)Application.Current.MainWindow).bus_list.SelectedIndex];
            InitializeComponent();
            Title = bus.Id;
            I_D.Content = bus.Id;
            start_date.Content = bus.StartDate;
            KM.Content = bus.Km;
            last_treat_km.Content = bus.LsaatTreastKm;
            gas.Content = bus.Gas;
            last_treat_date.Content = bus.LastTreatDate.ToString();
            timeTo.Content = bus.Time;
        }

        private void refule_Click(object sender, RoutedEventArgs e)
        {

        }

        private void treatment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

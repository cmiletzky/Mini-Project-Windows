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

namespace PL.Travel_information
{
    /// <summary>
    /// Interaction logic for TravelInformation.xaml
    /// </summary>
    public partial class TravelInformation : Page
    {
        public TravelInformation()
        {
            InitializeComponent();
            stop_list.ItemsSource = MainWindow.bl.presentStopsLine();
        }

        private void stop_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station stop = (BO.Station)stop_list.SelectedValue;
            stop_num.Text = stop.Code.ToString();
            stop_name.Text = stop.Name;

            lines_in_stop.ItemsSource = MainWindow.bl.GetLinsInStop(stop.Code);
        }
    }
}

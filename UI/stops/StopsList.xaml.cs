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
    /// Interaction logic for StopsList.xaml
    /// </summary>
    public partial class StopsList : Window
    {
         BO.LineBus  line;
        public StopsList(IEnumerable<BO.Station> list,ref BO.LineBus lineTo)
        {
            InitializeComponent();
            stop_list.ItemsSource = list;
            line = lineTo;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            BO.Station a = (BO.Station)stop_list.SelectedValue;
           // line.StationList.Add(new BO.StopOfLine(line.Id, a.Code, 0));
            Close();
        }
    }
}

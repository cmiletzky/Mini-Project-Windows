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
        public GetDataStops(BO.Station preStop , BO.Station newStop)
        {
            InitializeComponent();
            name_of_pre.Text = preStop.Name;
            num_of_pre.Text = preStop.Code.ToString();

            name_of_new.Text = newStop.Name;
            num_of_new.Text = newStop.Code.ToString();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

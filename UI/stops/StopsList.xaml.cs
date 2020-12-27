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
        public StopsList(IEnumerable<BO.Station> list)
        {
            InitializeComponent();
            stop_list.ItemsSource = list;
            stop_list.DisplayMemberPath = "Code";
        }
    }
}

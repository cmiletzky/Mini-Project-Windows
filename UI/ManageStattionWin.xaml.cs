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

namespace PL
{
    /// <summary>
    /// Interaction logic for ManageStattionWin.xaml
    /// </summary>
    public partial class ManageStattionWin : Window
    {
        public ManageStattionWin(ref ListBox list)
        {
            ListBox listOfLine = list;
            InitializeComponent();
        }

        private void add_station_click(object sender, RoutedEventArgs e)
        {


        }
    }
}

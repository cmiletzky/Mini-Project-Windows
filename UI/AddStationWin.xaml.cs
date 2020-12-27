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
    /// Interaction logic for AddStationWin.xaml
    /// </summary>
    public partial class AddStationWin : Window
    {
        public AddStationWin(ref ListBox stopList)
        {
            ListBox list = stopList;
            InitializeComponent();
            
        }
       
       // MainWindow.bl.AddStation(new_stat_name.Text, new_stat_code.Text, new_stat_longtitude.Text, new_stat_latitude.Text);    
    }
}

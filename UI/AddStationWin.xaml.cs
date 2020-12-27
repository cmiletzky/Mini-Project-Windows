using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void Add_station_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bl.AddStation(new_stat_name.Text, new_stat_code.Text, new_stat_longtitude.Text, new_stat_latitude.Text);
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("Station with this code allredy exsist");
            }
           
        }

        void validationNumbers(TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
       

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            validationNumbers(e);
        }

        private void NumberValidationTextB(object sender, TextCompositionEventArgs e)
        {
            validationNumbers(e);
        }

        private void NumberValidationTextBo(object sender, TextCompositionEventArgs e)
        {
            validationNumbers(e);
        }
    }
}

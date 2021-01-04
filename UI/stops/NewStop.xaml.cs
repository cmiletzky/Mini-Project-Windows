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
    /// Interaction logic for NewStop.xaml
    /// </summary>
    public partial class NewStop : Window
    {
        public NewStop()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bl.AddStation(name.Text.ToString(), num.Text.ToString(), longitude.Text.ToString(), latitude.Text.ToString());
                MessageBox.Show("התחנה נוספה בהצלחה");
                Close();
            }
            catch (Exception w)
            {

                MessageBox.Show(w.Message);        
            }
        }
    }
}

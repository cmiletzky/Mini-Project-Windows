using BL.BO;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for StartTrip.xaml
    /// </summary>
    public partial class StartTrip : Window
    {
        Bus busToTrip;
        public StartTrip(Bus busTo, Button cmd)
        {
            InitializeComponent();
            busToTrip = busTo;
        }

        private void Add_km(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MainWindow.canDrive = false;
               MainWindow.canDrive = MainWindow.bl.canDrive(busToTrip,  input_val.Text);
                if (MainWindow.canDrive)
                {
                    Close();
                    MessageBox.Show("The journey began");
                   
                }
                else
                {
                    MessageBox.Show(MainWindow.arrMes);
                }
            }
        }

       
        /// <summary>
        /// validation that only numbers insert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //}
    }
}

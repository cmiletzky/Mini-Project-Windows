using PL.UserControls;
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
    /// Interaction logic for NewBus.xaml
    /// </summary>
    public partial class NewBus : Window
    {
        ListBox list;
        public NewBus(ref ListBox listBox)
        {
            InitializeComponent();
            list = listBox;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Checks whether enough digits have been entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCh(object sender, TextChangedEventArgs e)
        {
            if (new_bus_id.Text.Length >= 7)
            {
                btn_add.IsEnabled = true;
            }
            else
            {
                btn_add.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bl.AddBus(new_bus_id.Text, date_start.SelectedDate);
                list.ItemsSource = MainWindow.bl.presentAllBus(false);
                MessageBox.Show("The bus was successfully added 🤗🤗", "successfully", MessageBoxButton.OK);
                Close();
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.Message);
            }
          
        }
    }
}

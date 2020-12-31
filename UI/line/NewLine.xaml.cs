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

namespace PL.line
{
    /// <summary>
    /// Interaction logic for NewLine.xaml
    /// </summary>
    public partial class NewLine : Window
    {
        int stop1;
        int stop2;
        ListBox listLine;
        public NewLine(ref ListBox list)
        {
            List<string> area = new List<string> { "General", "North", "South", "Center", "Jerusalem" };
            InitializeComponent();
            listLine = list;
            first_stop.ItemsSource = MainWindow.bl.presentAllStation(false);
            last_stop.ItemsSource = MainWindow.bl.presentAllStation(false);
            area_list.ItemsSource = area;
        }

        private void con_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (first_stop.SelectedIndex==-1||last_stop.SelectedIndex==-1||area_list.SelectedIndex==-1||line_num.Text=="")
                {
                    throw new Exception("חובה למלא את כל השדות");
                }
                BO.Station first = (BO.Station)first_stop.SelectedValue;
                BO.Station last = (BO.Station)last_stop.SelectedValue;
                stop1 = first.Code;
                stop2 = last.Code;
                MainWindow.bl.AddLine(int.Parse(line_num.Text), area_list.SelectedItem.ToString(),stop1,stop2);
                listLine.ItemsSource = MainWindow.bl.presentAllLines(false);
                Close();

            }
            catch (Exception d)
            {

                MessageBox.Show(d.Message);
            }
        }

        private void first_stop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (first_stop.SelectedIndex == last_stop.SelectedIndex)
            {
                MessageBox.Show("יש לבחור תחנה שונה מתחנת הסיום");
                first_stop.SelectedIndex = -1;
            }

        }

        private void last_stop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (last_stop.SelectedIndex == first_stop.SelectedIndex)
            {
                MessageBox.Show("יש לבחור תחנה שונה מתחנת ההתחלה");
                last_stop.SelectedIndex = -1;
            }
        }

        private void line_num_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void line_num_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (line_num.Text.Length >= 1)
            {
                save.IsEnabled = true;
            }
            else
            {
                save.IsEnabled = false;
            }
        }
    }
}

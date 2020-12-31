using PL.stops;
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
    /// Interaction logic for UpdateLine.xaml
    /// </summary>
    public partial class UpdateLine : Window
    {
        BO.LineBus lineTo;
        int oldLineNum;
        ListBox listLine;
        public UpdateLine(BO.LineBus line,ref ListBox listBox)
        {
            InitializeComponent();
            lineTo = line;
            listLine = listBox;
            oldLineNum = line.LineNum;

            List<string> area = new List<string> { "General", "North", "South", "Center", "Jerusalem" };
            Title = "line number " + line.LineNum.ToString();
            line_num.Text = line.LineNum.ToString();
            line_area.ItemsSource = area;
            line_area.SelectedIndex = area.IndexOf(lineTo.Area.ToString());
            list_stop_of_line.ItemsSource = line.Stops;
            
        }

        private void remove_stop_from_line_Click(object sender, RoutedEventArgs e)
        {
            if (list_stop_of_line.Items.Count==2)
            {
                MessageBox.Show("לא ניתן להחזיק פחות מ 2 תחנות בקו");
            }
            else
            {
                Button cdn = (Button)sender;
                BO.Station a = (BO.Station)cdn.DataContext;

                if (list_stop_of_line.Items.IndexOf(a) != 0 && list_stop_of_line.Items.IndexOf(a) != list_stop_of_line.Items.Count - 1)
                {
                    BO.Station befor = (BO.Station)list_stop_of_line.Items[list_stop_of_line.Items.IndexOf(a) - 1];
                    BO.Station aftet = (BO.Station)list_stop_of_line.Items[list_stop_of_line.Items.IndexOf(a) + 1];
                    if (MainWindow.bl.CheckAdjacentStatision(befor.Code, aftet.Code) == false)
                    {
                        MainWindow.bl.AddAdjacentStatision(befor.Code, aftet.Code, (aftet.DistanceFromPrivios + a.DistanceFromPrivios).ToString(), aftet.TimeFromPrivios + a.TimeFromPrivios);
                    }
                }
                MainWindow.bl.RemoveStopFromLine(lineTo.LineNum, a.Code);
                list_stop_of_line.ItemsSource = MainWindow.bl.presentStopsOfLine(lineTo.LineNum);
            }
          
        }

        private void add_stop_to_line_Click(object sender, RoutedEventArgs e)
        {

            if (list_stop_of_line.SelectedItems.Count==0)
            {
                if (MessageBox.Show("התחנה תתווסף בראש הרשימה, כדי להוסיף במיקום אחר יש לבחור את התחנה שלאחריה תתווסף התחנה החדשה", "חשוב", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    new StopsList(ref lineTo, (BO.Station)list_stop_of_line.Items[0]).ShowDialog();
                }
            }
            else if (list_stop_of_line.SelectedIndex == lineTo.Stops.Count()-1)
            {
                new StopsList(ref lineTo, (BO.Station)list_stop_of_line.SelectedItem,1).ShowDialog();
            }
            else
            {
                new StopsList(ref lineTo, (BO.Station)list_stop_of_line.SelectedItem, (BO.Station)list_stop_of_line.Items[list_stop_of_line.SelectedIndex+1], (BO.Station)list_stop_of_line.Items[0]).ShowDialog();
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bl.EditLine(oldLineNum, int.Parse(line_num.Text), line_area.SelectedItem.ToString());
                listLine.ItemsSource = MainWindow.bl.presentAllLines(false);
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }

            Close();
        }

        private void list_stop_of_line_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            BO.Station ee = (BO.Station)list_stop_of_line.SelectedValue;
            add_stop_to_line.Content = "הוסף תחנה אחרי תחנה : " + ee.Name;
        }

        private void edit_time_and_dis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button cmd = (Button)sender;
                BO.Station stop2 = (BO.Station)cmd.DataContext;
                BO.Station stop1 = lineTo.Stops[lineTo.Stops.IndexOf(stop2) - 1];

                new EditDataStopOfLine(stop1, stop2).ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("יש לשמור ולהכנס שוב");
            }


        }
    }
}

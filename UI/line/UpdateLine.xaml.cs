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
        public UpdateLine(BO.LineBus line)
        {
            InitializeComponent();
            lineTo = line;
            string[] area = { "General", "North", "South", "Center", "Jerusalem" };
            Title = "line number " + line.LineNum.ToString();
            line_num.Text = line.LineNum.ToString();
            line_area.ItemsSource = area;
            list_stop_of_line.ItemsSource = line.Stops;
        }

        private void remove_stop_from_line_Click(object sender, RoutedEventArgs e)
        {
            Button cdn = (Button)sender;
            BO.Station a = (BO.Station)cdn.DataContext;
            //TODO לטפל בהסרה נכונה
            MainWindow.bl.RemoveStopFromLine(lineTo.LineNum, a.Code);
            list_stop_of_line.ItemsSource = MainWindow.bl.presentStopsOfLine(lineTo.LineNum);

            // int index =  lineTo.StationList.IndexOf(a);
            //TODO לשלוח את הלוגיקה לביזנס
            //   lineTo.StationList.RemoveAt(index);
        }

        private void add_stop_to_line_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("התחנה תתווסף בראש הרשימה, כדי להוסיף במיקום אחר יש לבחור את התחנה שלאחריה תתווסף התחנה החדשה","חשוב",MessageBoxButton.OKCancel)==MessageBoxResult.OK)
            {
                new StopsList(MainWindow.bl.presentAllStation(false),ref lineTo).ShowDialog();
            }
        }
    }
}

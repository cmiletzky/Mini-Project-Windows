using PL.line;
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
         BO.LineBus  line;
        BO.Station preStop;
        BO.Station firstStop;
        ListBox listStopOfLine;
        public StopsList(IEnumerable<BO.Station> list,ref BO.LineBus lineTo, ref ListBox listStopOfLine, BO.Station preStop, BO.Station firstStop)
        {
            InitializeComponent();
            stop_list.ItemsSource = list;
            line = lineTo;
            this.preStop = preStop;
            this.firstStop = firstStop;
            this.listStopOfLine = listStopOfLine;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            listStopOfLine.ItemsSource = MainWindow.bl.presentAllLines(false);
      
            Close();
        }

        private void add_stop_to_line_Click(object sender, RoutedEventArgs e)
        {
            BO.Station newStop = (BO.Station)stop_list.SelectedValue;
            try
            {


                //TODO לבדוק תחנות עוקובת 
                if ( preStop != null&&MainWindow.bl.CheckAdjacentStatision(preStop.Code, newStop.Code) == false)
                {
                    new GetDataStops(preStop, newStop).ShowDialog();
                    MainWindow.bl.AddStopLine(newStop.Code, line.LineNum, preStop.IndexInLine);
                    Close();
                }
               else if (preStop == null && MainWindow.bl.CheckAdjacentStatision(firstStop.Code, newStop.Code) == false)
                {
                    new GetDataStopsForFirst(firstStop, newStop).ShowDialog();
                    MainWindow.bl.AddStopLine(newStop.Code, line.LineNum, 0);
                }
                else
                {
                    MainWindow.bl.AddStopLine(newStop.Code, line.LineNum, preStop.IndexInLine);
                }

                Close();
            }
            catch (Exception w)
            {

                MessageBox.Show(w.Message);
            }

        }
    }
}

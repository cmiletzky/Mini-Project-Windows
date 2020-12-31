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
        BO.Station nextStop;
        BO.Station firstStop;
       // ListBox listStopOfLine;
        public StopsList(ref BO.LineBus lineTo, BO.Station preStop,BO.Station nextStop, BO.Station firstStop)
        {
            InitializeComponent();
            stop_list.ItemsSource = MainWindow.bl.presentAllStation(false);
            line = lineTo;
            this.preStop = preStop;
            this.nextStop = nextStop;
            this.firstStop = firstStop;
          //  this.listStopOfLine.ItemsSource = lineTo.Stops;
        }

        public StopsList(ref BO.LineBus lineTo, BO.Station firstStop)
        {
            InitializeComponent();
            stop_list.ItemsSource = MainWindow.bl.presentAllStation(false);
            line = lineTo;
            this.firstStop = firstStop;
            this.preStop = null;
                
        } public StopsList(ref BO.LineBus lineTo, BO.Station lastStop,int a)
        {
            InitializeComponent();
            stop_list.ItemsSource = MainWindow.bl.presentAllStation(false);
            line = lineTo;
            this.firstStop = null;
            this.preStop = lastStop;
                
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

           // listStopOfLine.ItemsSource = MainWindow.bl.presentAllLines(false);
      
            Close();
        }

        private void add_stop_to_line_Click(object sender, RoutedEventArgs e)
        {
            BO.Station newStop = (BO.Station)stop_list.SelectedValue;
            try
            {
                MainWindow.bl.CheckStopIsInLine(newStop.Code, line.LineNum);

                //TODO לבדוק תחנות עוקובת 
                if (firstStop!= null&& preStop != null/*&&MainWindow.bl.CheckAdjacentStatision(preStop.Code, newStop.Code) == false*/)
                {
                    new GetDataStops(preStop, newStop,nextStop).ShowDialog();
                    MainWindow.bl.AddStopLine(newStop.Code, line.LineNum, preStop.IndexInLine+1);
                    Close();
                }
               else if (preStop == null && MainWindow.bl.CheckAdjacentStatision(firstStop.Code, newStop.Code) == false)
                {
                    new GetDataStops(firstStop, newStop).ShowDialog();
                    MainWindow.bl.AddStopLine(newStop.Code, line.LineNum, 1);
                }
                else if (firstStop == null && MainWindow.bl.CheckAdjacentStatision(preStop.Code, newStop.Code) == false)
                {
                    new GetDataStops(preStop, newStop , 1,1).ShowDialog();
                    MainWindow.bl.AddStopLine(newStop.Code, line.LineNum, preStop.IndexInLine + 1);
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

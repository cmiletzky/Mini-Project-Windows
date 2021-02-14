using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.Travel_information
{
    /// <summary>
    /// Interaction logic for TravelInformation.xaml
    /// </summary>
    public partial class TravelInformation : Page
    {
        BackgroundWorker worker;
        volatile bool stop = false;
        public TravelInformation()
        {
            InitializeComponent();
            stop_list.ItemsSource = MainWindow.bl.presentStopsLine();
            worker = new BackgroundWorker();
            worker.DoWork += doWork;
            worker.ProgressChanged += progressChanged;
            worker.RunWorkerCompleted += runWorkerCompleted;
            
        }

        private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void doWork(object sender, DoWorkEventArgs e)
        {

            int counter = 0;
            while (!stop)
            {
                //time.
                Thread.Sleep(1000);
                counter++;
               // worker.ReportProgress(counter);
            }
            e.Result = counter;

         //   MainWindow.bl.StartSimulator();
        }

        private void stop_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station stop = (BO.Station)stop_list.SelectedValue;
            stop_num.Text = stop.Code.ToString();
            stop_name.Text = stop.Name;

            lines_in_stop.ItemsSource = MainWindow.bl.GetLinsInStop(stop.Code);
        }

        private void start_watch_Click(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                stop = false;
                start_watch.Content = "עצור שעון";
                worker.RunWorkerAsync("hello");
                
            }
            else
            {
                start_watch.Content = "הפעל שעון";
                stop = true;
            }
        }
    }
}

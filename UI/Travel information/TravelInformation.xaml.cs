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

        int s;
        int m;
        int h;
        public TravelInformation()
        {
            InitializeComponent();
            stop_list.ItemsSource = MainWindow.bl.presentStopsLine();
            worker = new BackgroundWorker();
            worker.DoWork += doWork;
            worker.ProgressChanged += progressChanged;
            worker.RunWorkerCompleted += runWorkerCompleted;
             s = int.Parse(time_s.Text);
            m = int.Parse(time_m.Text);
            h = int.Parse(time_h.Text);

        }

        private void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
          
        }

        private void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
       
        private void doWork(object sender, DoWorkEventArgs e)
        {
            
            Action actiona = () =>h = int.Parse(time_h.Text); // represent the time on the screen
            Dispatcher.BeginInvoke(actiona);
            Action actionb = () => s= int.Parse(time_s.Text); // represent the time on the screen
            Dispatcher.BeginInvoke(actionb);
            Action actionc = () => m = int.Parse(time_m.Text); // represent the time on the screen
            Dispatcher.BeginInvoke(actionc);


            int counter = 0;
            while (!stop)
            {
                Thread.Sleep(1000);
              
              

                if (s < 59)
                {
                    s++;
                }else if (s == 59)
                {
                    s = 0;
                    if (m < 59)
                    {
                        m++;
                    }else if (m == 59)
                    {
                        m = 0;
                        if (h<24)
                        {
                            h++;
                        }
                        else if(h==24)
                        {
                            h = 0;
                        }
                    }
                }
                Action action5 = () => time_h.Text = h.ToString(); // represent the time on the screen
                Dispatcher.BeginInvoke(action5);
                    Action action4 = () => time_s.Text = s.ToString(); // represent the time on the screen
                Dispatcher.BeginInvoke(action4);
                Action action3 = () => time_m.Text = m.ToString(); // represent the time on the screen
                Dispatcher.BeginInvoke(action3);
             
                
                
               

                
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
                time_h.IsEnabled = false;
                time_m.IsEnabled = false;
                time_s.IsEnabled = false;
            }
            else
            {
                start_watch.Content = "הפעל שעון";
                stop = true;
                time_h.IsEnabled = true;
                time_m.IsEnabled = true;
                time_s.IsEnabled = true;
            }
        }

        private void refrsh_Click(object sender, RoutedEventArgs e)
        {
            if (stop_list.SelectedIndex==-1)
            {
                MessageBox.Show("נא לבחור תחנה");
            }
            else
            {
                string n = h.ToString() + ":" + m.ToString() + ":" + s.ToString();
                now.Text = n;
                BO.Station a = (BO.Station)stop_list.SelectedItem; 
              real_data.ItemsSource =  MainWindow.bl.getDataStop(a.Code,h,m);
            }
           
        }
    }
}

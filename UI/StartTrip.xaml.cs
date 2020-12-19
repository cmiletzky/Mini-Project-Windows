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

namespace PL
{
    /// <summary>
    /// Interaction logic for StartTrip.xaml
    /// </summary>
    public partial class StartTrip : Window
    {
        public StartTrip()
        {
            InitializeComponent();
        }

        //    private void Add_km(object sender, KeyEventArgs e)
        //    {

        //        if (e.Key == Key.Enter)

        //        {
        //            // check the condition wether the bus can take the drive
        //            if (busToDriv.Gas - int.Parse(input_val.Text) <= 0)
        //            {
        //                MessageBox.Show("there is no enough gas fo driving");
        //            }
        //            else if (((busToDriv.LsaatTreastKm) + int.Parse(input_val.Text)) > 20000)
        //            {
        //                MessageBox.Show("you need take the bus to treatment, over km treatment");
        //            }
        //            else if ((CheckingDate(busToDriv.LastTreatDate.ToString())))
        //            {
        //                MessageBox.Show("over a year past since the last treatment");
        //            }

        //            // if all the condition is ok take drive and update the right fildes
        //            else
        //            {

        //                Random k = new Random();
        //                double trip_time = double.Parse(input_val.Text) / k.Next(20, 50);
        //                Thread t3 = new Thread(
        //                    () =>
        //                    {

        //                        busToDriv.InDriving = true;


        //                        busToDriv.SeePro = "Visible";
        //                        busToDriv.Color = "#00FFFF";
        //                        busToDriv.Regull = 0;
        //                        Action action1 = () => ((MainWindow)Application.Current.MainWindow).bus_list.Items.Refresh();
        //                        Dispatcher.BeginInvoke(action1);
        //                        for (int i = 0; i < 100; i++)
        //                        {
        //                            busToDriv.refull += 1;

        //                            Thread.Sleep((int)trip_time * 6000 / 100);
        //                            Action action2 = () => ((MainWindow)Application.Current.MainWindow).bus_list.Items.Refresh();
        //                            Dispatcher.BeginInvoke(action2);
        //                        }
        //                        busToDriv.Color = "";
        //                        busToDriv.InDriving = false;
        //                        busToDriv.SeePro = "Hidden";
        //                        MessageBox.Show("bus number " + busToDriv.Id + " finish his trip");
        //                    }
        //                    );
        //                t3.Start();
        //                busToDriv.Km += int.Parse(input_val.Text);
        //                busToDriv.LsaatTreastKm += int.Parse(input_val.Text);
        //                busToDriv.Gas -= int.Parse(input_val.Text);
        //                ((MainWindow)Application.Current.MainWindow).bus_list.Items.Refresh();
        //                Close();
        //            }

        //        }
        //    }

        //    /// <summary>
        //    /// validation that only numbers insert
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        //    {
        //        Regex regex = new Regex("[^0-9]+");
        //        e.Handled = regex.IsMatch(e.Text);
        //    }

        //}
    }
}

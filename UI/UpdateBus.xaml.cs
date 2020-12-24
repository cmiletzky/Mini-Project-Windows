using BL.BO;
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
    /// Interaction logic for UpdateBus.xaml
    /// </summary>
    public partial class UpdateBus : Window
    {
        ListBox listBox;
        public UpdateBus(Bus bus, ref ListBox list)
        {
            InitializeComponent();
            listBox = list;
            Title = "Update "+bus.Id;
            I_D.Text = bus.Id;
            start_date.Text = bus.StartDate.ToString();
            KM.Text = bus.Km.ToString();
            last_treat_km.Text = bus.LsaatTreastKm.ToString();
            gas.Text = bus.Gas.ToString();
            last_treat_date.Text = bus.LastTreatDate.ToString();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string a = I_D.Text.Replace("-", "");
            Bus busTo = new Bus(a, start_date.SelectedDate);
            busTo.Km =int.Parse(KM.Text);
            busTo.LsaatTreastKm = int.Parse(last_treat_km.Text);
            busTo.Gas = int.Parse(gas.Text);
            busTo.LastTreatDate = last_treat_date.SelectedDate;
            MainWindow.bl.updateBus(busTo);
            listBox.ItemsSource = MainWindow.bl.presentAllBus(false);
        }
    }
}

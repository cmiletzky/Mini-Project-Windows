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
     
        public UpdateLine(BO.LineBus line)
        {
            InitializeComponent();
            string[] area = { "General", "North", "South", "Center", "Jerusalem" };
            Title = "line number " + line.LineNum.ToString();
            line_num.Text = line.LineNum.ToString();
            line_area.ItemsSource = area;
            list_stop_of_line.ItemsSource = line.StationList;
        }
    }
}

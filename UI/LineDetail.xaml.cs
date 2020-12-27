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
    /// Interaction logic for LineDetailxaml.xaml
    /// </summary>
    public partial class LineDetail : Window
    {
        public LineDetail(BO.LineBus line)
        {
            InitializeComponent();
            Title = "line number " + line.LineNum.ToString();
            line_num.Content = line.LineNum;
            line_area.Content = line.Area;
            list_stop_of_line.ItemsSource = MainWindow.bl.presentStopsOfLine(line.Id);
            


        }
    }
}

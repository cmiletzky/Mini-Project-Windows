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
    /// Interaction logic for EditDataStopOfLine.xaml
    /// </summary>
    public partial class EditDataStopOfLine : Window
    {
        public EditDataStopOfLine(BO.Station stop1 , BO.Station stop2)
        {
            InitializeComponent();
        }
    }
}

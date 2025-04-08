using Airport.View.Pages.Flights.UpdateFlights;
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

namespace Airport.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateFlightWindow.xaml
    /// </summary>
    public partial class UpdateFlightWindow : Window
    {
        public UpdateFlightWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new UpdateFlightButtonPage());
        }

        
    }
}

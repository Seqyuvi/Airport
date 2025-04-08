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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airport.View.Pages.Flights.UpdateFlights
{
    /// <summary>
    /// Логика взаимодействия для UpdateFlightButtonPage.xaml
    /// </summary>
    public partial class UpdateFlightButtonPage : Page
    {
        public UpdateFlightButtonPage()
        {
            InitializeComponent();
        }

        private void Update_Button_1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateFlightPage());
        }

        private void Update_Button_2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateDataPage());
        }

        private void Update_Button_3_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateAirPage());
        }

        private void Update_Button_4_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateAirportPage());
        }
    }
}

using Airport.Controllers.Flights;
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

namespace Airport.View.Pages.Flights
{
    /// <summary>
    /// Логика взаимодействия для AllFlightsPage.xaml
    /// </summary>
    public partial class AllFlightsPage : Page
    {
        private readonly AllFlightsController _flightController;
        public AllFlightsPage()
        {
            InitializeComponent();
            _flightController = new AllFlightsController();
            var flights = _flightController.AllFlightGet();
            
            Flights_DataGrid.ItemsSource = flights;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterFlights_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddFlight_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddFlightsPage());
        }
    }
}

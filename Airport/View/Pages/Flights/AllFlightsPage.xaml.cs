using Airport.Controllers.Flights;
using Airport.Helpers.ModelHelper;
using Airport.View.Pages.Flights.UpdateFlights;
using Airport.View.Windows;
using Airport.ViewModel.FlightsViewModel;
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
            FlightHelper.idFlight = 0;
            _flightController = new AllFlightsController();
            if(_flightController.AllFlightGet().Count() == 0)
            {
                
                    var result = MessageBox.Show("Рейсов не найдено, добавить?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.NavigationService.Navigate(new AddFlightsPage());
                    }
                    else
                    {
                        this.NavigationService.Navigate(new AllFlightsPage());
                    }
                
            }
            else
            {
                if (FindFlightHelper.idFlight.Count() == 0)
                {
                    var flights = _flightController.AllFlightGet();

                    Flights_DataGrid.ItemsSource = flights;
                    ClearSearh_Button.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ClearSearh_Button.Visibility = Visibility.Visible;
                    List<FlightViewModel> flights = new List<FlightViewModel>();
                    for (int i = 0; i < FindFlightHelper.idFlight.Count(); i++)
                    {
                        flights.Add(_flightController.GetFlight(FindFlightHelper.idFlight[i]));
                    }
                    Flights_DataGrid.ItemsSource = flights;
                    
                }

            }
           
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                
                if (button.DataContext is FlightViewModel item)
                {
                    
                    var detailsPage = new MoreInformationPage(item);

                    
                    this.NavigationService.Navigate(detailsPage);
                }
            }
        }

       

        private void AddFlight_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddFlightsPage());
        }

		private void ClearSearh_Button_Click(object sender, RoutedEventArgs e)
		{
			var flights = _flightController.AllFlightGet();

			Flights_DataGrid.ItemsSource = flights;
			ClearSearh_Button.Visibility = Visibility.Collapsed;
		}

		private void DeleteAllFlight_Button_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}

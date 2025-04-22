using Airport.Controllers.Flights.UpdateController;
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
using Airport.Controllers.Airline;
using Airport.Controllers.Airplane;
using Airport.Helpers.ModelHelper;
using Airport.View.Pages.CartTicket;

namespace Airport.View.Pages.Flights.UpdateFlights
{
    /// <summary>
    /// Логика взаимодействия для UpdateAirPage.xaml
    /// </summary>
    public partial class UpdateAirPage : Page
    {
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private readonly UpdateController _updateController;
        private readonly AirlineController _airlineController;
        private readonly AirplaneController _airplaneController;
        public UpdateAirPage()
        {
            InitializeComponent();
            _moreInformationFlightController = new MoreInformationFlightController();
            _updateController = new UpdateController();
            _airlineController = new AirlineController();
            _airplaneController = new AirplaneController();

            var information = _moreInformationFlightController.GetMore(FlightHelper.idFlight);

            Airline_ComboBox.ItemsSource = _airlineController.GetAllAirlines().Select(x => x.TitleAirlane).ToList();
            Airplane_ComboBox.ItemsSource = _airplaneController.GetAllAirplane().Select(x => x.TitleAirplane).ToList();
        }

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            var airline = Airline_ComboBox.SelectedValue != null ? Airline_ComboBox.SelectedValue.ToString() : "";
            var airplane = Airplane_ComboBox.SelectedValue != null ? Airplane_ComboBox.SelectedValue.ToString() : "";
            var resultUp = _updateController.Update3(FlightHelper.idFlight, airline, airplane);
            if(resultUp == true)
            {
                var result = MessageBox.Show("Успешно обновлено, вернуться обратно?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new UpdateFlightButtonPage());
                }
                else
                {
                    this.NavigationService.Navigate(new UpdateAirPage());
                }
            }
        }
    }
}

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
using Airport.Repositories.AirportRepo;
using Airport.Helpers.ModelHelper;
using Airport.Models;

namespace Airport.View.Pages.Flights.UpdateFlights
{
    /// <summary>
    /// Логика взаимодействия для UpdateAirportPage.xaml
    /// </summary>
    public partial class UpdateAirportPage : Page
    {
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private readonly UpdateController _updateController;
        private readonly AddFlightController _addFlightController;
        public UpdateAirportPage()
        {
            InitializeComponent();
            _moreInformationFlightController = new MoreInformationFlightController();
            _updateController = new UpdateController();
            _addFlightController = new AddFlightController();

            var information = _moreInformationFlightController.GetMore(FlightHelper.idFlight);

            ArrivalAirport_ComboBox.ItemsSource = _addFlightController.GetAllAirports().Select(x => x.CodeIATA).ToList();
            DepartureAirport_ComboBox.ItemsSource = _addFlightController.GetAllAirports().Select(x => x.CodeIATA).ToList();
        }

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            var arrAir = ArrivalAirport_ComboBox.SelectedValue != null ? ArrivalAirport_ComboBox.SelectedValue.ToString() : "";
            var depAir = DepartureAirport_ComboBox.SelectedValue != null ? DepartureAirport_ComboBox.SelectedValue.ToString() : "";
            var resultUp =  _updateController.Update4(FlightHelper.idFlight, arrAir, depAir);
            
            if (resultUp == true)
            {
                var result = MessageBox.Show("Успешно обновлено, вернуться обратно?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new UpdateFlightButtonPage());
                }
                else
                {
                    this.NavigationService.Navigate(new UpdateAirportPage());
                }
            }
        }
    }
}

using Airport.Controllers.Flights;
using Airport.Controllers.Flights.UpdateController;
using Airport.Controllers.Gates;
using Airport.Helpers.ModelHelper;
using Airport.Models;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Airport.View.Pages.Flights.UpdateFlights
{
    /// <summary>
    /// Логика взаимодействия для UpdateFlightPage.xaml
    /// </summary>
    public partial class UpdateFlightPage : Page
    {
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private readonly AllFlightsController _allFlightsController;
        private readonly UpdateController _updateController;
        private readonly GatesController _gatesController;
        public UpdateFlightPage()
        {
            InitializeComponent();
            _moreInformationFlightController = new MoreInformationFlightController();
            _allFlightsController = new AllFlightsController();
            _updateController = new UpdateController();
            _gatesController = new GatesController();
                
            var information = _moreInformationFlightController.GetMore(FlightHelper.idFlight);

            FlightNumber_TextBox.Text = information.FlightNumber;
            Status_ComboBox.ItemsSource = _allFlightsController.GetAllStatus().Select(x => x.TitleStatus).ToList();
            Gate_ComboBox.ItemsSource = _gatesController.GatesRepository().Select(x => x.GateNumber).ToList();


        }

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            var status = Status_ComboBox.SelectedValue != null ? Status_ComboBox.SelectedValue.ToString() : "";
            var gate = Gate_ComboBox.SelectedValue != null ? Gate_ComboBox.SelectedValue.ToString() : "";
            var resultUp = _updateController.Update1(FlightHelper.idFlight, FlightNumber_TextBox.Text, status, gate);

            if (resultUp == true)
            {
                var result = MessageBox.Show("Успешно обновлено, вернуться обратно?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new UpdateFlightButtonPage());
                }
                else
                {
                    this.NavigationService.Navigate(new UpdateFlightPage());
                }
            }
        }
    }
}

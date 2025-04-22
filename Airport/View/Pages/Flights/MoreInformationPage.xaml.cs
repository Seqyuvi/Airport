using Airport.Controllers.Flights;
using Airport.Helpers.ModelHelper;
using Airport.View.Pages.Passanger;
using Airport.View.Pages.Registration;
using Airport.View.Pages.TicketSelling;
using Airport.View.Windows;
using Airport.ViewModel.FlightsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для MoreInformationPage.xaml
    /// </summary>
    public partial class MoreInformationPage : Page
    {
        private readonly MoreInformationFlightController _moreInformationFlightController;
        private int idFlight = 0;
       
        public MoreInformationPage(FlightViewModel item)
        {
            InitializeComponent();
            _moreInformationFlightController = new MoreInformationFlightController();
            DataContext = item;
            var information = _moreInformationFlightController.GetMore(item.IdFlight);
            InformationFlight_TextBlock.Text = $"Information Flight: {information.FlightNumber}";
            DepartureDate_TextBlock.Text = information.DepartureDate;
            ArrivalDate_TextBlock.Text = information.ArrivalDate;
            DepartureTime_TextBlock.Text= information.DepartureTime;
            ArrivalTime_TextBlock.Text= information.ArrivalTime;
            DepartureAirport_TextBlock.Text = information.AirportDeparture;
            ArrivalAirport_TextBlock.Text = information.AirportArrival;
            DepartureAirportCode_TextBlock.Text = information.AirportDepartureCode;
            ArrivalAirportCode_TextBlock.Text = information.AirportArrivalCode;
            AirLines_TextBlock.Text = information.AirLine;
            Airplane_TextBlock.Text = information.Airplane;
            TotalSeats_TextBlock.Text = information.TotalSeats.ToString();
            TotalSeatsFree_TextBlock.Text = information.TotalSeatsFree.ToString();
            Status_TextBlock.Text = information.Status;
            GateNumber_TextBlock.Text = information.GateNumber;


            idFlight = information.IdFlight;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TicketSell_Button_Click(object sender, RoutedEventArgs e)
        {
            FlightHelper.idFlight = idFlight;
            this.NavigationService.Navigate(new TicketSellingPage());
        }

        private void UpdateFlight_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlightWindow updateFlightWindow = new UpdateFlightWindow();
            FlightHelper.idFlight = idFlight;
            updateFlightWindow.Show();
        }

        private void DeleteFlight_Button_Click(object sender, RoutedEventArgs e)
        {
            // Показываем MessageBox с подтверждением
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить \" Рейс {InformationFlight_TextBlock.Text.Split().Last()}\"?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            // Если пользователь подтвердил удаление
            if (result == MessageBoxResult.Yes)
            {
                _moreInformationFlightController.DeleteFlight(idFlight);
                MessageBox.Show("Элемент удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new AllFlightsPage());
            }
        }

        private void CheckPassanger_Click(object sender, RoutedEventArgs e)
        {
            FlightHelper.idFlight = idFlight;
            this.NavigationService.Navigate(new PassangerListPage());
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            FlightHelper.idFlight = idFlight;
            this.NavigationService.Navigate(new RegistrationPage());
        }
    }
}

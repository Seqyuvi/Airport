using Airport.Controllers.Airline;
using Airport.Controllers.Airplane;
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
using Xceed.Wpf.Toolkit;

namespace Airport.View.Pages.Flights
{
    /// <summary>
    /// Логика взаимодействия для AddFlightsPage.xaml
    /// </summary>
    public partial class AddFlightsPage : Page
    {
        private readonly AddFlightController _flightController;
        private readonly AirlineController _airlineController;
        private readonly AirplaneController _airplaneController;
        public AddFlightsPage()
        {
            InitializeComponent();
            _flightController = new AddFlightController();
            _airlineController = new AirlineController();
            _airplaneController = new AirplaneController();

            Airline_ComboBox.ItemsSource = _airlineController.GetAllAirlines().Select(x => x.TitleAirlane).ToList();
            DepartureAirprot_ComboBox.ItemsSource = _flightController.GetAllAirports().Select(x => x.CodeIATA).ToList();
            ArrivalAirport_ComboBox.ItemsSource = _flightController.GetAllAirports().Select(x => x.CodeIATA).ToList();
            Airplane_ComboBox.ItemsSource = _airplaneController.GetAllAirplane().Select(x => x.TitleAirplane).ToList();





        }

        private void AddFlight_Button_Click_1(object sender, RoutedEventArgs e)
        {
            _flightController.AddFlight(
                FlightNumber_TextBox.Text,
                Airline_ComboBox.SelectedItem.ToString(),
                ArrivalAirport_ComboBox.SelectedItem.ToString(),
                DepartureAirprot_ComboBox.SelectedItem.ToString(),
                new DateTime(Convert.ToInt32(DepartureDate_DatePicker.Text.Split('.')[2]), Convert.ToInt32(DepartureDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(DepartureDate_DatePicker.Text.Split('.')[0])),
                new DateTime(Convert.ToInt32(ArrivalDate_DatePicker.Text.Split('.')[2]), Convert.ToInt32(ArrivalDate_DatePicker.Text.Split('.')[1]), Convert.ToInt32(ArrivalDate_DatePicker.Text.Split('.')[0])),
                new TimeSpan(Convert.ToInt32(DepartureTime_DatePicker.Text.Split(':')[0]), Convert.ToInt32(DepartureTime_DatePicker.Text.Split(':')[1]), 0),
                new TimeSpan(Convert.ToInt32(ArrivalTime_DatePicker.Text.Split(':')[0]), Convert.ToInt32(ArrivalTime_DatePicker.Text.Split(':')[1]), 0),
                Convert.ToInt32(TotalSeatsFree_TextBox.Text),
                Airplane_ComboBox.SelectedItem.ToString()

                );
            System.Windows.MessageBox.Show($"{FlightNumber_TextBox.Text} | {Airline_ComboBox.SelectedItem.ToString()} | {DepartureAirprot_ComboBox.SelectedItem.ToString()} | {ArrivalAirport_ComboBox.SelectedItem.ToString()} | {Airplane_ComboBox.SelectedItem.ToString()}" +
                $"| {TotalSeatsFree_TextBox.Text} | {ArrivalDate_DatePicker.Text} | {DepartureDate_DatePicker.Text} | {ArrivalTime_DatePicker.Text} | {DepartureTime_DatePicker.Text}");
        }

        private void Airplane_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as WatermarkComboBox;
            var selectedItem = comboBox.SelectedItem;

            if (selectedItem != null)
            {
                
                    TotalSeatsFree_TextBox.Text = Convert.ToString(_airplaneController.GetAllAirplane().First(x => x.TitleAirplane
                    == Airplane_ComboBox.SelectedItem.ToString()).TotalSeats);
            }

           
        }
    }
    
}

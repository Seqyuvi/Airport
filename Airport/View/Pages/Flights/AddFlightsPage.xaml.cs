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
    /// Логика взаимодействия для AddFlightsPage.xaml
    /// </summary>
    public partial class AddFlightsPage : Page
    {
        private readonly AddFlightController _controller;
        public AddFlightsPage()
        {
            InitializeComponent();
            _controller = new AddFlightController();
            AirportArrival_ComboBox.ItemsSource = _controller.GetAllAirports().Select(x => x.CodeIKAO);
            AirportArrival_ComboBox.SelectedValuePath = "CodeIKAO";

        }

        private void AddFlight_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

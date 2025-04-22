using Airport.View.Pages;
using Airport.View.Pages.CartTicket;
using Airport.View.Pages.Flights;
using Airport.View.Pages.Passanger;
using Airport.View.Pages.Registration;
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

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void AllFlights_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllFlightsPage());
        }

        private void FindFlights_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FindFlightPage());
        }

        private void FindPassanger_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FindPassangerPage());
        }

        private void CartTicket_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CartTicketPage());
        }

        private void CheckAllTicket_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PassangerListPage());
        }

        private void AllRegistration_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllRegistrationPassangerPage());
        }

        private void AllPassangers_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PassangerListPage());
        }
    }
}

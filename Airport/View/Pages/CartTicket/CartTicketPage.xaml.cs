using Airport.Controllers.Booking;
using Airport.Controllers.Ticket;
using Airport.Helpers.ModelHelper;
using Airport.View.Pages.Flights;
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

namespace Airport.View.Pages.CartTicket
{
    /// <summary>
    /// Логика взаимодействия для CartTicketPage.xaml
    /// </summary>
    public partial class CartTicketPage : Page
    {
        private readonly TicketSellingController _ticketSellingController;
        private readonly BookingsController _bookingsController;
        public CartTicketPage()
        {
            InitializeComponent();
            FlightHelper.idFlight = 0;
            _ticketSellingController = new TicketSellingController();
            _bookingsController = new BookingsController();
            Cart_DataGrid.ItemsSource = TickerSellingCartServiceHelper.ListTicket;
        }

        private void BuyTicket_Button_Click(object sender, RoutedEventArgs e)
        {

            if(TickerSellingCartServiceHelper.ListTicket.Count() > 0)
            {
                _bookingsController.CreateBooking();

                foreach (var item in TickerSellingCartServiceHelper.ListTicket)
                {
                    _ticketSellingController.TicketBuy(item);
                }

                TickerSellingCartServiceHelper.ListTicket.Clear();
                Cart_DataGrid.Items.Refresh();

			}
            else
            {
                var result = MessageBox.Show("Корзина пуста, перейти к рейсам?", "Переход", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new AllFlightsPage());
                }
                else
                {
                    this.NavigationService.Navigate(new CartTicketPage());
                }
            }
        }

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Button button)
			{

				if (button.DataContext is Models.TicketsSelling item)
				{
                    var id = new Models.TicketsSelling();
					for(int i = 0; i < TickerSellingCartServiceHelper.ListTicket.Count(); i++)
					{
                        if (TickerSellingCartServiceHelper.ListTicket[i].IdTicketSelling == item.IdTicketSelling)
                        {
                            id = TickerSellingCartServiceHelper.ListTicket[i];
                        }
					}
                    TickerSellingCartServiceHelper.ListTicket.Remove(id);
					Cart_DataGrid.Items.Refresh();



				}
			}
		}
	}
}

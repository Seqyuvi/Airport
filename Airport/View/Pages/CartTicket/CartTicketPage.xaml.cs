using Airport.Controllers.Booking;
using Airport.Controllers.Ticket;
using Airport.Helpers.ModelHelper;
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
            _ticketSellingController = new TicketSellingController();
            _bookingsController = new BookingsController();
            Cart_DataGrid.ItemsSource = TickerSellingCartServiceHelper.ListTicket;
        }

        private void BuyTicket_Button_Click(object sender, RoutedEventArgs e)
        {
            _bookingsController.CreateBooking();

            foreach (var item in TickerSellingCartServiceHelper.ListTicket)
            {
                _ticketSellingController.TicketBuy(item);
            }
        }
    }
}

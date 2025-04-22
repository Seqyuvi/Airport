using Airport.Helpers.ModelHelper;
using Airport.Repositories.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Booking
{
    public class BookingTicketsController
    {
        private readonly BookingTicketsRepository _bookingTicketsRepository;
        public BookingTicketsController()
        {
            _bookingTicketsRepository = new BookingTicketsRepository();
        }

        public bool TicketPlusBooking(int idTicketSelling)
        {
            try
            {
                var lastBookingTicket = _bookingTicketsRepository.GetAll().Last();
                if (lastBookingTicket != null)
                {
                var result = _bookingTicketsRepository.Create
                    (
                        new Models.BookingTickets
                        {
                            IdBookingTicket = lastBookingTicket.IdBookingTicket + 1,
                            IdBooking = BookingMiodelHelper.IdBooking,
                            IdTicketSelling = idTicketSelling,
                        }
                    );
                if (result) return true; else return false;

                }else return false;
                
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка создания бронирования: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception(ex.Message);
            }
            

        }
    }
}

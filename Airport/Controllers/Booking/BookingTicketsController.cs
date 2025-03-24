using Airport.Helpers.ModelHelper;
using Airport.Repositories.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var lastBookingTicket = _bookingTicketsRepository.GetAll().Last();
            _bookingTicketsRepository.Create
                (
                    new Models.BookingTickets
                    {
                        IdBookingTicket = lastBookingTicket.IdBookingTicket + 1,
                        IdBooking = BookingMiodelHelper.IdBooking,
                        IdTicketSelling = idTicketSelling,
                    }
                );
            return true;

        }
    }
}

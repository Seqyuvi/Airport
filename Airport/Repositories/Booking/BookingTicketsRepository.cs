using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Repositories.Booking
{
    public class BookingTicketsRepository
    {
        private readonly Core _db;
        public BookingTicketsRepository()
        {
            _db = new Core();
        }
        public bool Create(BookingTickets bookingTickets)
        {
            _db.context.BookingTickets.Add(bookingTickets);
            _db.context.SaveChanges();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookingTickets> GetAll()
        {
            return _db.context.BookingTickets.ToList();
        }

        public Task<bool> Update(int id, int bookingId, int ticketSellingId)
        {
            throw new NotImplementedException();
        }
    }
}

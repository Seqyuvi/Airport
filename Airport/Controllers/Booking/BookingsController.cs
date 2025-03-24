using Airport.Helpers.ModelHelper;
using Airport.Models;
using Airport.Repositories.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Controllers.Booking
{
    public class BookingsController
    {
        private readonly BookingsRepository _bookingRepository;
        public BookingsController()
        {
            _bookingRepository = new BookingsRepository();
        }

        public bool CreateBooking()
        {
            var lastBooking = _bookingRepository.GetAll()
                .Last();

            var bookingNew = new Bookings
            {
                IdBooking = lastBooking.IdBooking + 1,
                BookingCode = GenerateBookingCode(lastBooking.BookingCode),
                BookingDate = DateTime.Now,
                TotalPrice = 0,
                IdBookingStatus = 1
            };

            _bookingRepository.Create(bookingNew);
            BookingMiodelHelper.IdBooking = bookingNew.IdBooking;
            BookingMiodelHelper.BookingCode = bookingNew.BookingCode;
            BookingMiodelHelper.BookingDate = bookingNew.BookingDate;
            BookingMiodelHelper.TotalPrice = bookingNew.TotalPrice;
            BookingMiodelHelper.IdBookingStatus = bookingNew.IdBookingStatus;
            return true;
        }


        private string GenerateBookingCode(string bookingCode)
        {
            int number = int.Parse(bookingCode.Substring(2));
            number += 1;
            string newCode = "BK" + number.ToString("D8");
            return newCode;
        }
    }
}

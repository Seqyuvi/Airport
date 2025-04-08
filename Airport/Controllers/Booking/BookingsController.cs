using Airport.Helpers.ModelHelper;
using Airport.Models;
using Airport.Repositories.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
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

                var result = _bookingRepository.Create(bookingNew);
                BookingMiodelHelper.IdBooking = bookingNew.IdBooking;
                BookingMiodelHelper.BookingCode = bookingNew.BookingCode;
                BookingMiodelHelper.BookingDate = bookingNew.BookingDate;
                BookingMiodelHelper.TotalPrice = bookingNew.TotalPrice;
                BookingMiodelHelper.IdBookingStatus = bookingNew.IdBookingStatus;
                if (result) return true; else return false;
               
               
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
                return false;
            }
           
        }


        private string GenerateBookingCode(string bookingCode)
        {
            try
            {
                int number = int.Parse(bookingCode.Split('0').Last());
                number += 1;
                string newCode = "BK" + number.ToString($"D{number.ToString().Length}");
                return newCode;
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
                return string.Empty;
            }
            
        }
    }
}

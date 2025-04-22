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
                var lastBooking = _bookingRepository.GetAll().Where(x => x.BookingCode != "")
               .Last();

                var bookingNew = new Bookings
                {
                    IdBooking = lastBooking.IdBooking + 1,
                    BookingCode = GenerateBookingCode(lastBooking.BookingCode),
                    BookingDate = DateTime.Now.Date,
                    TotalPrice = 0,
                    IdBookingStatus = 1
                };

                var result = _bookingRepository.Create(bookingNew);
                if (result == true)
                {
                    BookingMiodelHelper.IdBooking = bookingNew.IdBooking;
                    BookingMiodelHelper.BookingCode = bookingNew.BookingCode;
                    BookingMiodelHelper.BookingDate = bookingNew.BookingDate;
                    BookingMiodelHelper.TotalPrice = bookingNew.TotalPrice;
                    BookingMiodelHelper.IdBookingStatus = bookingNew.IdBookingStatus;
                    return true;

                }
                else return false;
                
               
               
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
                string numericPart = new string(bookingCode.Where(char.IsDigit).ToArray()).TrimStart('0');
                int number = numericPart.Length > 0 ? int.Parse(numericPart) : 0;
                number += 1;
                string newCode = "BK" + number.ToString($"D{8 - number.ToString().Length}");
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

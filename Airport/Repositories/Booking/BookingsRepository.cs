using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.Booking
{
    public class BookingsRepository
    {

        private readonly Data.Core _db;
        public BookingsRepository()
        {
            _db = new Data.Core();
        }

        /// <summary>
        /// Работа с БД. Создание бронирования
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Create(Bookings booking)
        {
            try
            {
                _db.context.Bookings.Add(booking);
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка добавления бронирования: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }
        

        

        /// <summary>
        /// Работа с БД. Получения списка всех броинрований
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Bookings> GetAll()
        {
            try
            {
                return _db.context.Bookings.ToList();

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }

        
    }
}

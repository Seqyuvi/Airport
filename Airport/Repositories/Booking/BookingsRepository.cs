using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _db.context.Bookings.Add(booking);
            _db.context.SaveChanges();
            return true;                    
        }
        /// <summary>
        /// Работа с БД. Удаление бронирования по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Работа с БД.  Получение бронирования по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<Bookings> Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Работа с БД. Получения списка всех броинрований
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Bookings> GetAll()
        {
           return _db.context.Bookings.ToList();
        }

        /// <summary>
        /// Работа с БД. Обновление бронирования по его id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookingCode"></param>
        /// <param name="bookingDate"></param>
        /// <param name="totalPrice"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Update(int id, string bookingCode, string bookingDate, string totalPrice, string statusId)
        {
            throw new NotImplementedException();
        }
    }
}

using Airport.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airport.Repositories.RegistrationTicket
{
    public class RegistrationRepository
    {
        private readonly Data.Core _db;
        public RegistrationRepository()
        {
            _db = new Data.Core();
        }

        /// <summary>
        /// Работа с БД. Создание регистрации на рейс
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Create(Registration registration)
        {
            _db.context.Registration.Add(registration);
            _db.context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Работа с БД. Удаление регистрации на рейс
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Delete(int statusId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Работа с БД. Получение всех регистраций
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<Registration>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Работа с БД. Обновление регистрации
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Update(int id, int statusId)
        {
            throw new NotImplementedException();
        }
    }
}

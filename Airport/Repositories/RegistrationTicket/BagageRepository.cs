using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Repositories.RegistrationTicket
{
    public class BagageRepository
    {

        private readonly Core _db;
        public BagageRepository()
        {
            _db = new Core();
        }
        /// <summary>
        /// Работа с БД. Создание багажа
        /// </summary>
        /// <param name="bagage"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Create(Bagage bagage)
        {
            _db.context.Bagage.Add(bagage);
            _db.context.SaveChanges();
            return true;
        }


        public List<Bagage> GetAll()
        {
            return _db.context.Bagage.ToList();
        }

        /// <summary>
        /// Работа с БД. Удаление багажа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Работа с БД. Обновление багажа
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> Update(int id, int count, int weight)
        {
            throw new NotImplementedException();
        }
    }
}

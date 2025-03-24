using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Repositories.Flights
{
    public class GatesRepository
    {
        private readonly Core _db;
        public GatesRepository()
        {
            _db = new Core();
        }

        /// <summary>
        /// Работа с БД. Получение всех гейтов
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Gates> GetAll()
        {
            return _db.context.Gates.ToList();
        }

        /// <summary>
        /// Работа с БД. Получение гейта по его номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Gates GetById(int id)
        {
            return _db.context.Gates.First(x => x.IdGate == id);
        }

        /// <summary>
        /// Работа с БД. Обновление гейта по его номеру. Обновление статуса
        /// </summary>
        /// <param name="GateNumber"></param>
        /// <param name="idStatus"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(int idGate, int idStatus)
        {
            _db.context.Gates.First(x => x.IdGate == idGate).IdStatusGate = idStatus;
            _db.context.SaveChanges();
            return true;
        }
    }
}

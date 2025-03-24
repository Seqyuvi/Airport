using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airport.Repositories
{
    public class UsersRepository
    {
        private readonly Data.Core _db;
        public UsersRepository()
        {
            _db = new Data.Core();
        }
        /// <summary>
        /// Работа с БД. Получение списка всех пользователей
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public  List<User> GetAll()
        {
            return _db.context.User.ToList();
        }
    }
}

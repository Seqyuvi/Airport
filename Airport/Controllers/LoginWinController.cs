﻿using Airport.Repositories;
using Airport.validation.GeneralValid;
using System;
using System.Linq;

namespace Airport.Controllers
{
    public class LoginWinController
    {
        private readonly UsersRepository _usersRepository;
        public LoginWinController()
        {
            _usersRepository = new UsersRepository();
        }

        /// <summary>
        /// Бизнес-логика авторизации диспетчера аэропрта
        /// </summary>
        /// <param name="login"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Authorization(string login, string password)
        {
            var user = _usersRepository.GetAll();
            bool valid = GeneralValidation.IsStringNullOrEmpty(login) && GeneralValidation.IsStringNullOrEmpty(login) ? true : false;
            if (valid == true)
            {
                var result = user.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
        public virtual List<User> GetAll()
        {
            try
            {
                return _db.context.User.ToList();

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

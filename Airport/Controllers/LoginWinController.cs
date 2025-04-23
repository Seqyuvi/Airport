using Airport.Repositories;
using Airport.validation.GeneralValid;
using System;
using System.Linq;
using System.Windows;

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
        /// Конструктор для тестов
        /// </summary>
        /// <param name="usersRepository"></param>
        public LoginWinController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        /// <summary>
        /// Бизнес-логика авторизации диспетчера аэропрта
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Authorization(string login, string password)
        {
            try
            {
                var user = _usersRepository.GetAll();
                bool valid = true;
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
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка входа: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }

            
        }
    }
}

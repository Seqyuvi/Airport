using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                int count = _db.context.Bagage.Count();
                _db.context.Bagage.Add(bagage);
                _db.context.SaveChanges();
                if (count < _db.context.Bagage.Count())
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }


        public List<Bagage> GetAll()
        {
            try
            {
                return _db.context.Bagage.ToList();

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

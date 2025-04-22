using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                return _db.context.Gates.ToList();

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

        /// <summary>
        /// Работа с БД. Получение гейта по его номеру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Gates GetById(int id)
        {
            try
            {
                return _db.context.Gates.First(x => x.IdGate == id);

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

        /// <summary>
        /// Работа с БД. Обновление гейта по его номеру. Обновление статуса
        /// </summary>
        /// <param name="GateNumber"></param>
        /// <param name="idStatus"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(int idGate, int idStatus)
        {
            try
            {
                _db.context.Gates.First(x => x.IdGate == idGate).IdStatusGate = idStatus;
                _db.context.SaveChanges();
                return true;

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
    }
}

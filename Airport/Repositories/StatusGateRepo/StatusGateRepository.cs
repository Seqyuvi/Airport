using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.StatusGateRepo
{
    public class StatusGateRepository
    {
        private readonly Core _db;
        public StatusGateRepository()
        {
            _db = new Core();
        }

        public List<StatusGate> GetAll()
        {
            try
            {
                return _db.context.StatusGate.ToList();

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

        public StatusGate GetByTitle(string title)
        {
            try
            {
                return _db.context.StatusGate.FirstOrDefault(x => x.StatusTitile == title);

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

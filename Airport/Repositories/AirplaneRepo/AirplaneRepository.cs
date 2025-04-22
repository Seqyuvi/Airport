using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.AirplaneRepo
{
    public class AirplaneRepository
    {
        private readonly Core _db;
        public AirplaneRepository()
        {
            _db = new Core();
        }

        public List<Airplane> GetAll()
        {
            try
            {
                return _db.context.Airplane.ToList();

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

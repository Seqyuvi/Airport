using Airport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.Airline
{
    public class AirlineRepository
    {
        private readonly Core _db;
        public AirlineRepository()
        {
            _db = new Core();
        }

        public List<Models.Airlines> GetAll()
        {
            try
            {
                return _db.context.Airlines.ToList();
                
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

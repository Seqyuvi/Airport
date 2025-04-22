using Airport.Data;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Repositories.AirportRepo

{
    public class AirportsRepository
    {
        public readonly Core _db;
        public AirportsRepository()
        {
            _db = new Core();
        }

        public List<Airports> GetAll()
        {
            try
            {
                return _db.context.Airports.ToList();
                

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

using Airport.Repositories.Airline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Airline
{
    public class AirlineController
    {
        private readonly AirlineRepository _airlineRepository;
        public AirlineController()
        {
            _airlineRepository = new AirlineRepository();
        }

        public List<Models.Airlines> GetAllAirlines()
        {
            try
            {
                return _airlineRepository.GetAll();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка Получения авиалиний: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        } 
    }
}

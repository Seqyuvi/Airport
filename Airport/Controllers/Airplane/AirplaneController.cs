using Airport.Repositories.AirplaneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Airplane
{
    
    public class AirplaneController
    {
        private readonly AirplaneRepository _airplaneRepository;
        public AirplaneController()
        {
            _airplaneRepository = new AirplaneRepository();
        }

        public List<Models.Airplane> GetAllAirplane()
        {
            try
            {
                return _airplaneRepository.GetAll();

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения самолётов: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }
    }
}

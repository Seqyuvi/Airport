using Airport.Repositories.Flight;
using Airport.ViewModel.FlightsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Flights
{
    public class MoreInformationFlightController
    {
        private readonly FlightsRepository _flightsRepository;
        public MoreInformationFlightController()
        {
            _flightsRepository = new FlightsRepository();
        }

        public MoreInformationViewModel GetMore(int id)
        {
            try
            {
                return _flightsRepository.GetFlightInformation(id);
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка доступа к информации о рейсе: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;

            }

        }

        public bool DeleteFlight(int id)
        {
            try
            {
                return _flightsRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка удаленяи рейса: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;

            }
        }
    }
}

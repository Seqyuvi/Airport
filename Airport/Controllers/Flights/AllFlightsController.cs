using Airport.Repositories.Flight;
using Airport.ViewModel.FlightsViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Flights
{
    public class AllFlightsController
    {
        private readonly FlightsRepository _flightsRepository;
        public AllFlightsController()
        {
            _flightsRepository = new FlightsRepository();
        }
        public List<FlightViewModel> AllFlightGet()
        {
            try
            {
                return _flightsRepository.GetAllFlightIncludeAirLine();

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

        public FlightViewModel GetFlight(int id)
        {
            try
            {
                return _flightsRepository.GetAllFlightIncludeAirLine().First(x => x.IdFlight == id);

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

        public List<Models.Status> GetAllStatus()
        {
            try
            {
                   return _flightsRepository.GetAllListStatus();

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

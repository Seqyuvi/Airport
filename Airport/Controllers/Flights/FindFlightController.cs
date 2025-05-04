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
    public class FindFlightController
    {
        private readonly FlightsRepository _flightsRepository;
        public FindFlightController()
        {
            _flightsRepository = new FlightsRepository();
        }

        public List<Models.Flights> FindFlight(int type, string info)
        {
            try
            {
                if(type == 1 || type == 2)
                {
					return _flightsRepository.GetFligthFind(type, info);
				}
                return new List<Models.Flights>();
                
            }
            catch(Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка поиска рейса: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
            
        }
    }
}

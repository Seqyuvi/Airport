using Airport.Repositories.Flight;
using Airport.ViewModel.FlightsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _flightsRepository.GetFligthFind(type, info);
        }
    }
}

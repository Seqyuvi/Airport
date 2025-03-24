﻿using Airport.Repositories.Flight;
using Airport.ViewModel.FlightsViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _flightsRepository.GetAllFlightIncludeAirLine();
        }


        public List<FlightViewModel> FiltersOn(int orderBy = 0, string arrivalCity = null, string departureCiry = null, string arrivalAirport = null, string departureAirport = null, string airLine = null, string status = null)
        {
            return _flightsRepository.GetAllFlightsOnFilter(orderBy, arrivalCity, departureCiry, arrivalAirport, departureAirport, airLine, status);
        }
    }
}

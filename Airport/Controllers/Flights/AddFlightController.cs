using Airport.Data;
using Airport.Models;
using Airport.Repositories.AirportRepo;
using Airport.Repositories.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Flights
{
    public class AddFlightController
    {
        private readonly FlightsRepository _flightsRepository;
        private readonly AirportsRepository _airportsRepository;
        private readonly Core _db;
        public AddFlightController()
        {
            _flightsRepository = new FlightsRepository();
            _airportsRepository = new AirportsRepository();
            _db = new Core();
        }

        public List<Airports> GetAllAirports()
        {
            try
            {
                return _airportsRepository.GetAll();

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка получения аэропортов: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }

        public bool AddFlight(string flightNumber, string airline, string airportArrival, string airportDeparture, DateTime departureDate, DateTime arrivalDate, 
            TimeSpan departureTime, TimeSpan arrivalTime, int TotalSeatsFree, string airplane, int Gate = 1, int Status = 1)
        {
            bool succsess = true;
            try
            {
                bool result = _flightsRepository.Create(new Models.Flights
                {
                    FlightNumber = flightNumber,
                    IdAirlane = _db.context.Airlines.FirstOrDefault(x => x.TitleAirlane == airline).IdAirline,
                    AirportDeparturesId = _airportsRepository.GetAll().FirstOrDefault(x => x.CodeIATA == airportDeparture).IdAirport,
                    ArrivalAirportId = _airportsRepository.GetAll().FirstOrDefault(x => x.CodeIATA == airportArrival).IdAirport,
                    DepartureDate = departureDate,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    ArrivalDate = arrivalDate,
                    TotalSeatsFree = TotalSeatsFree,
                    IdStatus = Status,
                    IdAirplane = _db.context.Airplane.FirstOrDefault(x => x.TitleAirplane == airplane).IdAirplane,
                    IdGate = Gate,

                });

                if (result) return true; else return false;
                
            }
            catch(Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка добавления рейса: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                succsess = false;
				
			}
            return succsess;
        }

        

    }
}

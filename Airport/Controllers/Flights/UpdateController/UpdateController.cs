using Airport.Helpers.ModelHelper;
using Airport.Repositories.Airline;
using Airport.Repositories.AirplaneRepo;
using Airport.Repositories.AirportRepo;
using Airport.Repositories.Flight;
using Airport.Repositories.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Controllers.Flights.UpdateController
{
    public class UpdateController
    {
        private readonly FlightsRepository _flightRepository;
        private readonly GatesRepository _gatesRepository;
        private readonly AirlineRepository _airlineRepository;
        private readonly AirplaneRepository _airplaneRepository;
        private readonly AirportsRepository _airportsRepository;
        public UpdateController()
        {
            
            _flightRepository = new FlightsRepository();
            _gatesRepository = new GatesRepository();
            _airlineRepository = new AirlineRepository();
            _airplaneRepository = new AirplaneRepository(); 
            _airportsRepository = new AirportsRepository();
        }

        public bool Update1(int id, string number, string status = "", string gate = "")
        {
            try
            {
                return _flightRepository.Update4(id,
                    number,
                    status != "" ? _flightRepository.GetAllListStatus().First(x => x.TitleStatus == status).IdStatus : 0,
                    gate != "" ? _gatesRepository.GetAll().First(x => x.GateNumber == gate).IdGate : 0);
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception($"Ошибка обновления: {ex.Message}");
            }
        }

        public bool Update2(int id, DateTime arrivalDate = new DateTime(), DateTime departureDate = new DateTime(), TimeSpan arrivalTime = new TimeSpan(), TimeSpan departureTime = new TimeSpan())
        {
            try
            {
                return _flightRepository.Update1(
                    id,
                    arrivalDate != new DateTime() ? arrivalDate : new DateTime(),
                    departureDate != new DateTime() ? departureDate : new DateTime(),
                    arrivalTime != new TimeSpan() ? arrivalTime : new TimeSpan(),
                    departureTime != new TimeSpan() ? departureTime : new TimeSpan()
                    );
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception($"Ошибка обновления: {ex.Message}");
            }
        }

        public bool Update3(int id, string airLine = "", string airPlane = "")
        {
            try
            {
                return _flightRepository.Update2(
                    id,
                    airLine != "" ? _airlineRepository.GetAll().First(x => x.TitleAirlane == airLine).IdAirline : 0,
                    airPlane != "" ? _airplaneRepository.GetAll().First(x => x.TitleAirplane == airPlane).IdAirplane : 0
                    
                    );
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception($"Ошибка обновления: {ex.Message}");
            }
        }

        public bool Update4(int id, string arrivalAirport = "", string deparureAirport = "")
        {
            try
            {
                return _flightRepository.Update3(
                    id,
                    arrivalAirport != "" ? _airportsRepository.GetAll().First(x => x.CodeIATA == arrivalAirport).IdAirport : 0,
                    deparureAirport != "" ? _airportsRepository.GetAll().First(x => x.CodeIATA == deparureAirport).IdAirport : 0

                    );
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                throw new Exception($"Ошибка обновления: {ex.Message}");
            }
        }
    }
}

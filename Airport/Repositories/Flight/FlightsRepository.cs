using Airport.ViewModel.FlightsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Airport.Models;
using System.Reflection;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows;


namespace Airport.Repositories.Flight
{
    public class FlightsRepository
    {
        private readonly Data.Core _db;
        public FlightsRepository()
        {
            _db = new Data.Core();
        }




        /// <summary>
        /// Работа с БД. Создание(добавление) рейса
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Create(Airport.Models.Flights flights)
        {
            try
            {
                int countFlight = _db.context.Flights.ToList().Count();
                _db.context.Flights.Add(flights);
                _db.context.SaveChanges();
                if (countFlight <= _db.context.Flights.ToList().Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка добавления рейса: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }


        }

        /// <summary>
        /// Работа с БД. Удаление рейса по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(int id)
        {
            try
            {
                int countFlight = _db.context.Flights.ToList().Count();
                _db.context.Flights.Remove(_db.context.Flights.FirstOrDefault(x => x.IdFlight == id));
                _db.context.SaveChanges();
                if (countFlight <= _db.context.Flights.ToList().Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка удаления рейса: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        /// <summary>
        /// Работа с БД. Удаление всез рейсов сразу
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteAll()
        {
            try
            {
                int countFlight = _db.context.Flights.ToList().Count();
                _db.context.Flights.RemoveRange(_db.context.Flights.ToList());
                _db.context.SaveChanges();
                if (countFlight <= _db.context.Flights.ToList().Count())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка удаления всех рейсов: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }

        }

        /// <summary>
        /// Работа с БД. Получение списка всех авиарейсов
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Airport.Models.Flights> GetAll()
        {
            try
            {
                return _db.context.Flights.ToList();

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

        public bool UpdateTotalSeatsFree(int id)
        {
            try
            {
                var model = GetAll().First(x => x.IdFlight == id);
                model.TotalSeatsFree -= 1;
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления мест рейса: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }


        /// <summary>
        /// Получение все рейсов с заменой id авиакомпании на её название
        /// </summary>
        /// <returns></returns>
        public List<FlightViewModel> GetAllFlightIncludeAirLine()
        {
            try
            {
                var list = _db.context.Flights
                    .Include(i => i.Airlines)
                    .Include(i => i.Airports)
                    .Include(i => i.Status)
                    .ToList()
                    .Select(f => new FlightViewModel
                    {
                        IdFlight = f.IdFlight,
                        FlightNumber = $"{f.FlightNumber}",
                        AirLine = $"{f.Airlines.TitleAirlane}",
                        AirportDeparture = $"{f.Airports.CodeIATA}",
                        AirportArrival = $"{f.Airports1.CodeIATA}",
                        DepartureDate = $"{f.DepartureDate.ToString("yyyy-MM-dd")}",
                        DepartureTime = $"{f.DepartureTime}",
                        ArrivalDate = $"{f.ArrivalDate.ToString("yyyy-MM-dd")}",
                        ArrivalTime = $"{f.ArrivalTime}",
                        Status = $"{f.Status.TitleStatus}"
                    }).ToList();
                return list;

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

       

        public MoreInformationViewModel GetFlightInformation(int id)
        {

            try
            {
                var flight = _db.context.Flights
                    .Include(i => i.Airlines)
                    .Include(i => i.Airports)
                    .Include(i => i.Status)
                    .Include(i => i.Gates)
                    .Include(i => i.Airplane)
                    .ToList()
                    .Select(f => new MoreInformationViewModel
                    {
                        IdFlight = f.IdFlight,

                        FlightNumber = $"{f.FlightNumber}",

                        DepartureDate = $"{f.DepartureDate.ToString("yyyy-MM-dd")}",
                        DepartureTime = $"{f.DepartureTime}",
                        ArrivalDate = $"{f.ArrivalDate.ToString("yyyy-MM-dd")}",
                        ArrivalTime = $"{f.ArrivalTime}",

                        AirportDeparture = $"{f.Airports.TitleAirport}",
                        AirportArrival = $"{f.Airports1.TitleAirport}",
                        AirportDepartureCode = $"{f.Airports.CodeIATA}",
                        AirportArrivalCode = $"{f.Airports1.CodeIATA}",

                        AirLine = $"{f.Airlines.TitleAirlane}",
                        Airplane = f.Airplane.TitleAirplane,
                        Status = $"{f.Status.TitleStatus}",
                        TotalSeats = f.Airplane.TotalSeats,
                        TotalSeatsFree = f.TotalSeatsFree,
                        GateNumber = f.Gates.GateNumber

                    })
                    .FirstOrDefault(x => x.IdFlight == id);



                return flight;

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

        public List<Models.Flights> GetFligthFind(int findType,string findInformation)
        {
            try
            {
                switch (findType)
                {
                    case 1:
                        var result = _db.context.Flights.Where(x => x.FlightNumber.ToUpper() == findInformation.ToUpper()).ToList();
                        if(result != null)
                        {
                            return result;
                        }
                        else
                        {
                            return null;
                        }
                    case 2:
                        var airportCheck = _db.context.Airports.FirstOrDefault(x => x.TitleAirport.ToUpper().Contains(findInformation.ToUpper()));
                        if(airportCheck != null)
                        {
                            var airport = airportCheck.IdAirport;
                            var resul = _db.context.Flights.Where(x => x.AirportDeparturesId == airport || x.ArrivalAirportId == airport).ToList();
                            return resul;

                        }
                        else
                        {
                            return null;
                        }
                }
                return null;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка поиска информации: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return null;
            }
        }

        public bool Update1(int id, DateTime arrivalDate = new DateTime(), DateTime departureDate = new DateTime(), TimeSpan arrivalTime = new TimeSpan(), TimeSpan departureTime = new TimeSpan())
        {
            try
            {
                var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
                model.ArrivalDate = arrivalDate != new DateTime() ? arrivalDate : model.ArrivalDate;
                model.DepartureDate = departureDate != new DateTime() ? departureDate : model.DepartureDate;
                model.ArrivalTime = arrivalTime != new TimeSpan() ? arrivalTime : model.ArrivalTime;
                model.DepartureTime = departureTime != new TimeSpan() ? departureTime : model.DepartureTime;
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        public bool Update2(int id, int airLine = 0, int airPlane = 0)
        {
            try
            {
                var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
                model.IdAirlane = airLine != 0 ? airLine : model.IdAirlane;
                model.IdAirplane = airPlane != 0 ? airPlane : model.IdAirplane;
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        public bool Update3(int id, int arrivalAirport = 0, int departureAirport =  0 )
        {
            try
            {
                var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
                model.AirportDeparturesId = departureAirport != 0 ? departureAirport : model.AirportDeparturesId;
                model.ArrivalAirportId = arrivalAirport != 0 ? arrivalAirport : model.ArrivalAirportId;
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        public bool Update4(int id, string number = null, int status = 0, int gate = 0)
        {
            try
            {
                var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
                model.FlightNumber = number != null ? number : model.FlightNumber;
                model.IdStatus = status != 0 ? status : model.IdStatus;
                model.IdGate = gate != 0 ? gate : model.IdGate;
                _db.context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(
                        messageBoxText: $"Ошибка обновления данных: {ex.Message}",
                        caption: "Ошибка",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
                });
                return false;
            }
        }

        public List<Models.Status> GetAllListStatus()
        {
            try
            {
                return _db.context.Status.ToList();

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

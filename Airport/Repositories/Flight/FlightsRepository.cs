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

        /// <summary>
        /// Работа с БД. Удаление рейса по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(int id)
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

        /// <summary>
        /// Работа с БД. Удаление всез рейсов сразу
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteAll()
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

        /// <summary>
        /// Работа с БД. Получение списка всех авиарейсов
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Airport.Models.Flights> GetAll()
        {
            return _db.context.Flights.ToList();
        }

        public bool UpdateTotalSeatsFree(int id)
        {
            var model = GetAll().First(x => x.IdFlight == id);
            model.TotalSeatsFree -= 1;
            _db.context.SaveChanges();
            return true;
        }


        /// <summary>
        /// Получение все рейсов с заменой id авиакомпании на её название
        /// </summary>
        /// <returns></returns>
        public List<FlightViewModel> GetAllFlightIncludeAirLine()
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

        public List<FlightViewModel> GetAllFlightsOnFilter(int orderBy, string arrivalCity, string departureCiry, string arrivalAirport, string departureAirport, string airLine, string status)
        {



            StringBuilder command = new StringBuilder("SELECT\r\n" +
                "  FlightNumber,\r\n\t" +
                "  Airplane.TitleAirplane,\r\n\t" +
                "  Airlines.TitleAirlane,\r\n\t" +
                "  Air1.CodeIATA,\r\n\t" +
                "  Air2.CodeIATA,\r\n\t" +
                "  DepartureDate,\r\n\t" +
                "  DepartureTime,\r\n\t" +
                "  ArrivalDate,\r\n\t" +
                "  ArrivalTime,\r\n\t" +
                "  Airport.dbo.Status.TitleStatus\r\n\r\n" +
                "  FROM Flights \r\n" +
                "  INNER JOIN Airports Air1 ON Flights.ArrivalAirportId = Air1.IdAirport \r\n" +
                "  INNER JOIN Airports  Air2 ON Flights.AirportDeparturesId = Air2.IdAirport\r\n" +
                "  INNER JOIN Airlines ON Flights.IdAirlane = Airlines.IdAirline\r\n" +
                "  INNER JOIN Airplane ON Flights.IdAirplane = Airplane.IdAirplane\r\n" +
                "  INNER JOIN Airport.dbo.Status ON Flights.IdStatus = Airport.dbo.Status.IdStatus\r\n\r\n");

            int count = 0;
            List<string> paras = new List<string>() { arrivalCity, departureCiry, arrivalAirport, departureAirport, airLine, status };
            foreach (var par in paras)
            {
                if (par != null)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                command.AppendLine(" WHERE ");
            }
            if (paras[0] != null) {  command.AppendLine($" (Air1.City LIKE '%{paras[0]}%') and \r\n"); }
            if (paras[1] != null) {  command.AppendLine($" (Air2.City LIKE '%{paras[1]}%') and\r\n");  }
            if (paras[2] != null) {  command.AppendLine($" (Air1.CodeIATA LIKE '%{paras[2]}%') and\r\n"); }
            if (paras[3] != null) {  command.AppendLine($" (Air2.CodeIATA LIKE '%{paras[3]}%') and\r\n"); }
            if (paras[4] != null) {  command.AppendLine($" (Airlines.TitleAirlane LIKE '%{paras[4]}%') and\r\n"); }
            if (paras[5] != null) {  command.AppendLine($" (Airport.dbo.Status.TitleStatus LIKE '%{paras[5]}%')\r\n"); }
            if (orderBy != 0) {
                string orderByStr = (orderBy == 1) ? "ASC" : "DESC";
               command.Append($"  ORDER BY FlightNumber '{orderByStr}' \r\n");
               }


            
			var list = _db.context.Flights.SqlQuery(command.ToString()).ToList();
            var result = list.Select(f => new FlightViewModel
             {
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

            return result;


        }


        public MoreInformationViewModel GetFlightInformation(int id)
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

        public List<Models.Flights> GetFligthFind(int findType,string findInformation)
        {
            switch (findType) 
            {
                case 1:
                    return _db.context.Flights.Where(x => x.FlightNumber == findInformation).ToList();
                    case 2:
                    var result = _db.context.Flights.SqlQuery(
                        "SELECT idFlight FROM Flights INNER JOIN Airports Air1 ON Flights.ArrivalAirportId = Air1.IdAirport" +
                        " INNER JOIN Airports  Air2 ON Flights.AirportDeparturesId = Air2.IdAirport" +
                        $" WHERE (Air1.TitleAirport LIKE '%@info%') or" +
                        $" WHERE (Air2.TitleAirprot LIKE '%@info%')"
                        , new SqlParameter("@info", findInformation)).ToList();
                    return result.Select(x => new Models.Flights{
                        IdFlight = x.IdFlight,
                        FlightNumber = x.FlightNumber,
                        IdAirlane = x.IdAirlane,
                        AirportDeparturesId = x.AirportDeparturesId,
                        ArrivalAirportId = x.AirportDeparturesId,
                        DepartureDate = x.DepartureDate,
                        DepartureTime = x.DepartureTime,
                        TotalSeatsFree = x.TotalSeatsFree,
                        IdStatus = x.IdStatus,
                        IdAirplane = x.IdAirplane,
                        IdGate = x.IdGate,
                        ArrivalDate = x.ArrivalDate,
                        ArrivalTime = x.ArrivalTime
                    }).ToList();

            }
            return null;
        }

        public bool Update1(int id, DateTime arrivalDate = new DateTime(), DateTime departureDate = new DateTime(), TimeSpan arrivalTime = new TimeSpan(), TimeSpan departureTime = new TimeSpan())
        {
            var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
            model.ArrivalDate = arrivalDate != new DateTime() ? arrivalDate : model.ArrivalDate;
            model.DepartureDate = departureDate != new DateTime() ? departureDate : model.DepartureDate;
            model.ArrivalTime = arrivalTime != new TimeSpan() ? arrivalTime : model.ArrivalTime;
            model.DepartureTime = departureTime != new TimeSpan() ? departureTime : model.DepartureTime;
            _db.context.SaveChanges();
            return true;
        }

        public bool Update2(int id, int airLine = 0, int airPlane = 0)
        {
            var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
            model.IdAirlane = airLine != 0 ? airLine : model.IdAirlane;
            model.IdAirplane = airPlane != 0 ? airPlane : model.IdAirplane;
            _db.context.SaveChanges();
            return true;
        }

        public bool Update3(int id, int arrivalAirport = 0, int departureAirport =  0 )
        {
            var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
            model.AirportDeparturesId = departureAirport != 0 ? departureAirport : model.AirportDeparturesId;
            model.ArrivalAirportId = arrivalAirport != 0 ? arrivalAirport : model.ArrivalAirportId;
            _db.context.SaveChanges();
            return true;
        }

        public bool Update4(int id, string number = null, int status = 0, int gate = 0)
        {
            var model = _db.context.Flights.FirstOrDefault(x => x.IdFlight == id);
            model.FlightNumber = number != null ? number : model.FlightNumber;
            model.IdStatus = status != 0 ? status : model.IdStatus;
            model.IdGate = gate != 0 ? gate : model.IdGate;
            _db.context.SaveChanges();
            return true;
        }

        public List<Models.Status> GetAllListStatus()
        {
            return _db.context.Status.ToList();
        }
        
    }
}

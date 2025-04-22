using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModel.FlightsViewModel
{
    public class MoreInformationViewModel
    {
        public int IdFlight { get; set; }
        public string FlightNumber { get; set; }
        public string AirLine { get; set; }
        public string AirportDeparture { get; set; }
        public string AirportArrival { get; set; }
        public string AirportDepartureCode { get; set; }
        public string AirportArrivalCode { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public string Status { get; set; }
        public int TotalSeats { get; set; }
        public int TotalSeatsFree { get; set; }
        public string GateNumber { get; set; }
        public string Airplane {  get; set; }
    }
}

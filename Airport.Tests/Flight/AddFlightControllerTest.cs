using Airport.Controllers.Flights;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Airport.Tests.Flight
{
	[TestClass]
	public class AddFlightControllerTest
	{
		[DataTestMethod]
		[DataRow("SU-100", "Aeroflot", "SVO", "IST", "2024.12.5", "2025.12.5", "12:05:00", "12:10:00", 189, "Boeing 737", true)]
		[DataRow("SU-100", "Aeroflot", "SVO", "IdwST", "2024.12.5", "2025.12.5", "12:05:00", "12:10:00", 189, "Boeing 737", false)]
		[DataRow("SU-100", "Aeroflot", "SVO", "IST", "2024.12.5", "2025.12.5", "12:05:00", "12:10:00", 189, "Boedwaing 737", false)]
		public void AddFlight_DataTest(string flightNumber, string airline, string airportArrival, string airportDeparture, string departureDate, string arrivalDate,
			string departureTime, string arrivalTime, int TotalSeatsFree, string airplane, bool expected, int Gate = 1, int Status = 1)
		{
			var controller = new AddFlightController();
			var actual = controller.AddFlight(flightNumber, airline, airportArrival, airportDeparture, Convert.ToDateTime(departureDate), Convert.ToDateTime(arrivalDate),
				new TimeSpan(Convert.ToInt32(
						departureTime.Split(':')[0]), Convert.ToInt32(departureTime.Split(':')[1]), Convert.ToInt32(departureTime.Split(':')[2])),
				new TimeSpan(Convert.ToInt32(
						arrivalTime.Split(':')[0]), Convert.ToInt32(arrivalTime.Split(':')[1]), Convert.ToInt32(arrivalTime.Split(':')[2])),
				TotalSeatsFree, airplane);
			Assert.AreEqual(expected, actual);
					
		}
	}
}

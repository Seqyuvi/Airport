using Airport.Controllers;
using Airport.Controllers.Booking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Airport.Tests.Booking
{
	[TestClass]
	public class BookingControllerTest
	{
		/// <summary>
		/// Проверка на создание кода бронирования
		/// </summary>
		[TestMethod]
		public void CreateBooking_TestMethod()
		{
			var controller = new BookingsController();
			var actual = controller.CreateBooking();
			Assert.AreEqual(true, actual);
		}
	}
}

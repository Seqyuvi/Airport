using Airport.Controllers.Booking;
using Airport.Controllers.Ticket;
using Airport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Airport.Tests.Ticket
{
	[TestClass]
	public class TicketSellingControllerTest
	{
		[TestMethod]
		public void TicketBy_Test()
		{
			var controllerTest = new BookingsController();
			controllerTest.CreateBooking();
			var controller = new TicketSellingController();
			var actual = controller.TicketBuy(new Models.TicketsSelling
			{

				IdFlight = 3,
				NumberTicket = 1011,
				PassportNumber = "1234-123456",
				PlaceOfIssue = "Moscow",
				DateOfIssue = new DateTime(2024, 12, 01),
				FirstName = "First",
				SecondName = "Second",
				Surname = "Sur",
				DateOfBirth = new DateTime(1988, 08, 15),
				BagageCount = 2,
				FormOfPaymentId = 1,
				Email = "email@email.com"

			});
			Assert.AreEqual(true, actual);
		}

		[TestMethod]
		public void TicketAddCart_Test()
		{
			var controller = new TicketSellingController();
			var actual = controller.TicketAddCart(3, "1234-123456", "Moscow", new DateTime(2024, 10, 15), "First", "Second", "Sur", new DateTime(2001, 12, 5), 1, "email", 0);
			Assert.AreEqual(true, actual);
		}
	}
}

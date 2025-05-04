using Airport.Controllers.Registration;
using Airport.Controllers.Ticket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Airport.Tests.Ticket
{
	[TestClass]
	public class PassangerFlightControllerTest
	{
		[DataTestMethod]
		[DataRow(4, true)]
		[DataRow(0, false)]
		public void Delete_DataTest(int id, bool expected)
		{
			var controller = new PassangerFlightController();
			var actual = controller.Delete(id);

			Assert.AreEqual(expected, actual);
		}
	}
}

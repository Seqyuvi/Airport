using Airport.Controllers.Flights;
using Airport.Controllers.Registration;
using Airport.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Airport.Tests.RegistrationTest
{
	[TestClass]
	public class RegistrationControllerTest
	{
		/// <summary>
		/// Тест метода регистрации на рейс
		/// </summary>
		/// <param name="idFlight"></param>
		/// <param name="passportNumber"></param>
		/// <param name="placeOfIssue"></param>
		/// <param name="dateOfIssue"></param>
		/// <param name="firstName"></param>
		/// <param name="secondName"></param>
		/// <param name="surName"></param>
		/// <param name="dateOfBirth"></param>
		/// <param name="countBagage"></param>
		/// <param name="weightBagage"></param>
		/// <param name="expected"></param>
		[DataTestMethod]
		[DataRow(2, "BC2345678", "Istanbul", "2025.02.21", "Maria", "Ivanovna", "Kuznetsova", "1990.08.20", 2, 35, true)]
		[DataRow(2, "BC2345678", " ", "2025.02.21", "Maria", "Ivanovna", "Kuznetsova", "1990.08.20", 2, 35, false)]
		[DataRow(2, "BC2345678", "Istanbul", "2025.02.21", "", "Ivanovna", "Kuznetsova", "1990.08.20", 2, 35, false)]
		[DataRow(1234, "BC2345678", "Istanbul", "2025.02.21", "", "Ivanovna", "Kuznetsova", "1990.08.20", 2, 35, false)]
		public void IsRegistered_DataTest(int idFlight, string passportNumber, string placeOfIssue, string dateOfIssue, 
			string firstName, string secondName, string surName, string dateOfBirth, int countBagage, int weightBagage, bool expected)
		{
			var controller = new RegistrationController();
			var actual = controller.IsRegistered(idFlight, passportNumber, placeOfIssue, Convert.ToDateTime(dateOfIssue), 
				firstName, secondName, surName, Convert.ToDateTime(dateOfBirth), countBagage, weightBagage);
			 
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CancelReg_Test()
		{
			var controller = new RegistrationController();
			var actual = controller.CancelledReg(5);
			Assert.AreEqual(true, actual);
		}
	}
}

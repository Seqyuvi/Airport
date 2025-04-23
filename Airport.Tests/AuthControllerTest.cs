using Airport.Controllers;
using Airport.Data;
using Airport.Models;
using Airport.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Airport.Tests
{
	[TestClass]
	public class AuthControllerTest
	{
        /// <summary>
        /// Тест на проверку метода входа в контроллере авторизации
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="expected"></param>
        [DataTestMethod]
        [DataRow("admin", "password123", true)]
        [DataRow("dwadaw", "password123", false)]
        [DataRow("admin", "dwdwa", false)]
        public void Authorization_DataTest(string login, string password, bool expected)
        {
            // Arrange
            var mockUsers = new List<User>
            {
                new User { Login = "admin", Password = "password123" }
            };

            var mockRepo = new Mock<UsersRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(mockUsers);

            var controller = new LoginWinController(mockRepo.Object);

            // Act
            var actual = controller.Authorization(login, password);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}

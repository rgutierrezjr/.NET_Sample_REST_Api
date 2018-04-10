using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTApiSample.Controllers;
using RESTApiSample.Models;

namespace RESTApiSample.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        IUserRepository repository;

        [TestMethod]
        public void TestGetUser()
        {
            // Arrange
            var controller = new UsersController(new DictionaryUserRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUser(5);

            // Assert
            Assert.AreEqual(5, response.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void TestGetUserNotFound()
        {
            // Arrange
            var controller = new UsersController(new DictionaryUserRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.GetUser(10);

            // Assert - Expect Exception HttpResponseException
        }

        [TestMethod]
        public void TestGetUsers()
        {
            // Arrange
            var controller = new UsersController(new DictionaryUserRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            IEnumerable<User> users = controller.GetUsers();

            // Assert
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void TestDeleteUserNotFound()
        {
            // Arrange
            var controller = new UsersController(new DictionaryUserRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Delete(20);

            // Assert - Expect Exception HttpResponseException
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void TestDeleteUser()
        {
            // Arrange
            var controller = new UsersController(new DictionaryUserRepository());
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var response = controller.Delete(1);

            // Assert 1: user is returned, deleted.
            Assert.IsNotNull(response);

            // Act
            var deletedUser = controller.GetUser(1);

            // Assert 2: Expect Exception, User no longer found.
        }

        [TestMethod]
        public void TestPostUser()
        {
            // Arrange
            var controller = new UsersController(new DictionaryUserRepository());
            controller.Request = new HttpRequestMessage(HttpMethod.Get, "http://localhost");
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
                                  new HttpConfiguration());

            User user = new User(0, "ruben", "gutierrez", "rgutierrez@bigboston.io", "password");

            // Act 1: Post
            HttpResponseMessage response = controller.Post(user);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }
    }
}

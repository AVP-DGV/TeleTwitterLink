using Moq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.Services.Data;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;

namespace TeleTwitterLink.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenSaverIsNull()
        {
            //Arrange
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserService(null, stubTwitterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object));

        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenIRepositoryTwitterUserIsNull()
        {
            //Arrange
            var stubSaver = new Mock<ISaver>();
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserService(stubSaver.Object, null, stubUsers.Object, stubUserTwitterUsers.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenIRepositoryUserIsNull()
        {
            //Arrange
            var stubSaver = new Mock<ISaver>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserService(stubSaver.Object, stubTwitterUsers.Object, null, stubUserTwitterUsers.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenIRepositoryUserTwitterUserIsNull()
        {
            //Arrange
            var stubSaver = new Mock<ISaver>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsers = new Mock<IRepository<User>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserService(stubSaver.Object, stubTwitterUsers.Object, stubUsers.Object, null));
        }
    }
}

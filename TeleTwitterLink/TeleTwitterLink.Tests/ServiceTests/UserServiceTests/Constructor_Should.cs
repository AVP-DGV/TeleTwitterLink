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
<<<<<<< HEAD
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
=======
            var stubTwitterterUsers = new Mock<IRepository<TwitterUser>>();
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
<<<<<<< HEAD
                () => new UserService(null, stubTwitterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object));
=======
                () => new UserService(null, stubTwitterterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object));
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c
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
<<<<<<< HEAD
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
=======
            var stubTwitterterUsers = new Mock<IRepository<TwitterUser>>();
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
<<<<<<< HEAD
                () => new UserService(stubSaver.Object, stubTwitterUsers.Object, null, stubUserTwitterUsers.Object));
=======
                () => new UserService(stubSaver.Object, stubTwitterterUsers.Object, null, stubUserTwitterUsers.Object));
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenIRepositoryUserTwitterUserIsNull()
        {
            //Arrange
            var stubSaver = new Mock<ISaver>();
<<<<<<< HEAD
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
=======
            var stubTwitterterUsers = new Mock<IRepository<TwitterUser>>();
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c
            var stubUsers = new Mock<IRepository<User>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
<<<<<<< HEAD
                () => new UserService(stubSaver.Object, stubTwitterUsers.Object, stubUsers.Object, null));
=======
                () => new UserService(stubSaver.Object, stubTwitterterUsers.Object, stubUsers.Object, null));
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c
        }
    }
}

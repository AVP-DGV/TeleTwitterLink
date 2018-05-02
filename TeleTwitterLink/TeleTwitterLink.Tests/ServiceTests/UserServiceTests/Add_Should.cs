using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;

namespace TeleTwitterLink.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class Add_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            var stubSaver = new Mock<ISaver>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            var service = new UserService(stubSaver.Object, stubTwitterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object);

            var mockTwitterUserDTO = new Mock<TwitterUserDTO>();

            Assert.ThrowsException<ArgumentNullException>(() => service.AddUser(mockTwitterUserDTO.Object, null));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            var stubSaver = new Mock<ISaver>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            var service = new UserService(stubSaver.Object, stubTwitterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object);

            var mockTwitterUserDTO = new Mock<TwitterUserDTO>();

            Assert.ThrowsException<ArgumentException>(() => service.AddUser(mockTwitterUserDTO.Object, string.Empty));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenTwitterUserDTOIsNull()
        {
            var stubSaver = new Mock<ISaver>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            var service = new UserService(stubSaver.Object, stubTwitterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object);
            var fakeString = "123";

            Assert.ThrowsException<ArgumentNullException>(() => service.AddUser(null, fakeString));
        }

        [TestMethod]
        public void ChangeIsDeletedToFalse_WhenDTOIsNotNullAndIsAlreadyAdded()
        {
            var stubSaver = new Mock<ISaver>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();

            var service = new UserService(stubSaver.Object, stubTwitterUsers.Object, stubUsers.Object, stubUserTwitterUsers.Object);

            var userDto = new TwitterUserDTO
            {
                TwitterUserId = "345",
                Name = "Zoro"
            };

            var user = new TwitterUser
            {
                TwitterUserId = userDto.TwitterUserId,
                Name = userDto.Name
            };

            //var users = new List<TwitterUser> { user };

            //stubTwitterUsers.Setup(s => s.AllAndDeleted).Returns(users.AsQueryable());

            //Act
            service.AddUser(userDto, "345");

            //Assert
            stubSaver.Verify(v => v.SaveChanges(), Times.Once);
        }
    }
}

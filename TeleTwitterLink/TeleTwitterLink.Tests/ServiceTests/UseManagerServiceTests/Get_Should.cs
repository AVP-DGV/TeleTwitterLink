using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data;
using TeleTwitterLInk.Data.Repository;

namespace TeleTwitterLink.Tests.ServiceTests.UseManagerServiceTests
{
    [TestClass]
    public class Get_Should
    {
        [TestMethod]
        public void ReturnUsersCorrect()
        {
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsersTweets = new Mock<IRepository<UserTweet>>();
            var stubTweets = new Mock<IRepository<Tweet>>();

            var service = new UserManagerService(stubUsers.Object, stubUserTwitterUsers.Object, stubTwitterUsers.Object, stubUsersTweets.Object, stubTweets.Object);

            var user = new UserDTO { TestName = "name" };
            var users = new List<UserDTO> { user };

            var xxx = service.GetAllUsers();
            //xxx = Setup(s => s.All).Returns(users);
            //service.GetAllUsers.Setup(s => s.AllAndDeleted).Returns(users.AsQueryable());

            //Assert.AreEqual(users, service.GetAllUsers());
        }
    }
}

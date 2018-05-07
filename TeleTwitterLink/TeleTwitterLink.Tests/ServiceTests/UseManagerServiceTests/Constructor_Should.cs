using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.Services.Data;
using TeleTwitterLInk.Data.Repository;

namespace TeleTwitterLink.Tests.ServiceTests.UseManagerServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenRepositoryUserIsNull()
        {
            //Arrange
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsersTweets = new Mock<IRepository<UserTweet>>();
            var stubTweets = new Mock<IRepository<Tweet>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserManagerService(null, stubUserTwitterUsers.Object, stubTwitterUsers.Object, stubUsersTweets.Object, stubTweets.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenRepositoryUserTwitterUserIsNull()
        {
            //Arrange
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsersTweets = new Mock<IRepository<UserTweet>>();
            var stubTweets = new Mock<IRepository<Tweet>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserManagerService(stubUsers.Object, null, stubTwitterUsers.Object, stubUsersTweets.Object, stubTweets.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenRepositoryTwitterUserIsNull()
        {
            //Arrange
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsersTweets = new Mock<IRepository<UserTweet>>();
            var stubTweets = new Mock<IRepository<Tweet>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserManagerService(stubUsers.Object, stubUserTwitterUsers.Object, null, stubUsersTweets.Object, stubTweets.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenRepositoryUserTweetIsNull()
        {
            //Arrange
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsersTweets = new Mock<IRepository<UserTweet>>();
            var stubTweets = new Mock<IRepository<Tweet>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserManagerService(stubUsers.Object, stubUserTwitterUsers.Object, stubTwitterUsers.Object, null, stubTweets.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenRepositoryTweetIsNull()
        {
            //Arrange
            var stubUsers = new Mock<IRepository<User>>();
            var stubUserTwitterUsers = new Mock<IRepository<UserTwitterUser>>();
            var stubTwitterUsers = new Mock<IRepository<TwitterUser>>();
            var stubUsersTweets = new Mock<IRepository<UserTweet>>();
            var stubTweets = new Mock<IRepository<Tweet>>();

            //Act && Assert
            Assert.ThrowsException<ArgumentNullException>(
                () => new UserManagerService(stubUsers.Object, stubUserTwitterUsers.Object, stubTwitterUsers.Object, stubUsersTweets.Object, null));
        }
    }
}

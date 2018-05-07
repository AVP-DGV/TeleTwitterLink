using System;
using System.Collections.Generic;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLInk.Data.Repository;

namespace TeleTwitterLink.Services.Data
{
    public class UserManagerService : IUserManagerService
    {
        private IRepository<User> users;
        private IRepository<UserTwitterUser> userTwitterUsers;
        private IRepository<TwitterUser> twitterUsers;
        private IRepository<UserTweet> userTweets;
        private IRepository<Tweet> tweets;
        
        public UserManagerService(
            IRepository<User> users,
            IRepository<UserTwitterUser> userTwitterUsers,
            IRepository<TwitterUser> twitterUsers,
            IRepository<UserTweet> userTweets,
            IRepository<Tweet> tweets)
        {
            this.users = users ?? throw new ArgumentNullException(); ;
            this.userTwitterUsers = userTwitterUsers ?? throw new ArgumentNullException(); ;
            this.twitterUsers = twitterUsers ?? throw new ArgumentNullException(); ;
            this.userTweets = userTweets ?? throw new ArgumentNullException(); ;
            this.tweets = tweets ?? throw new ArgumentNullException(); ;
        }

        public IList<UserDTO> GetAllUsers()
        {
            var users = this.users.All
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    TestName = x.TestName,
                    UserTweet = x.UserTweet,
                    UserTwitterUsers = x.UserTwitterUsers
                })
                .ToList();

            return users;
        }

        public IList<TwitterUserDTO> TakeFavouriteTwitterUsers(string aspUserId)
        {
            var twitterUsersIds = this.userTwitterUsers.All
                .Where(x => x.UserId == aspUserId)
                .Select(x => x.TwitterUserId)
                .ToList();

            var aspUser = this.users.All.First(x => x.Id == aspUserId);

            var aspUserDTO = new UserDTO()
            {
                CreatedOn = aspUser.CreatedOn,
                DeletedOn = aspUser.DeletedOn,
                Email = aspUser.Email
            };

            var twitterUsers = this.twitterUsers.All
                .Where(x => twitterUsersIds.Contains(x.Id))
                .Select(x => new TwitterUserDTO()
                {
                    Description = x.Description,
                    FollowersCount = x.FollowersCount,
                    FriendsCount = x.FriendsCount,
                    ImgUrl = x.ImgUrl,
                    Location = x.Location,
                    Name = x.Name,
                    CretedOn = x.CreatedOn,
                    TwitterUserId = x.TwitterUserId,
                    User = aspUserDTO
                })
                .ToList();

            return twitterUsers;
        }

        public IList<TweetDTO> TakeFavouriteTweetsOfUser(string aspUserId)
        {
            var tweetIds = this.userTweets.All
                .Where(x => x.UserId == aspUserId)
                .Select(x => x.TweetId)
                .ToList();

            var tweets = this.tweets.All
                .Where(x => tweetIds.Contains(x.Id))
                .Select(x => new TweetDTO()
                {
                    CreatedAt = x.CreatedAt,
                    Text = x.Text,
                    TweetId = x.TweetId,
                    TwitterUser = new TwitterUserDTO()
                    {
                        Name = x.TwitterUser.Name
                    }
                })
                .ToList();

            return tweets;
        }
    }
}

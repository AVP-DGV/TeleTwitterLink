using System;
using System.Collections.Generic;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;

namespace TeleTwitterLink.Services.Data
{
    public class TweetService : ITweetService
    {
        private readonly ISaver saver;
        private IRepository<Tweet> tweets;
        private IRepository<TwitterUser> twitterUsers;
        private IRepository<User> aspUsers;
        private IRepository<UserTweet> userTweet;

        public TweetService(ISaver saver, IRepository<Tweet> tweets, IRepository<TwitterUser> twitterUsers)
        {
            this.saver = saver;
            this.tweets = tweets;
            this.twitterUsers = twitterUsers;
        }

        public void SaveTweet(TweetDTO dto, string aspUserId)
        {
            var existingTweetInDb = this.tweets.All
                .FirstOrDefault(x => x.TweetId == dto.TweetId);

            if (existingTweetInDb == null)
            {
                bool isAlreadyBeenSaved = this.userTweet.AllAndDeleted
                    .Any(x => x.TweetId == existingTweetInDb.Id && x.UserId == aspUserId);

                if (isAlreadyBeenSaved)
                {
                    var existingEntity = this.userTweet.AllAndDeleted
                        .First(x => x.TweetId == existingTweetInDb.Id && x.UserId == aspUserId);

                    existingEntity.IsDeleted = false;

                    this.userTweet.Update(existingEntity);
                }
                else
                {
                    existingTweetInDb.UserTweet = new List<UserTweet>();

                    existingTweetInDb.UserTweet.Add(new UserTweet()
                    {
                        UserId = aspUserId
                    });
                }
            }
            else
            {
                var twitterUserIdInDb = this.twitterUsers.AllAndDeleted
                    .FirstOrDefault(x => x.Name == dto.ScreenName);

                if (twitterUsers == null)
                {
                    throw new Exception("You cannot save tweet of user that is not in collection of favourite users.");
                }

                var model = new Tweet
                {
                    Text = dto.Text,
                    TweetId = dto.TweetId,
                    TwitterUserId = twitterUserIdInDb.Id,
                    UserTweet = new List<UserTweet>()
                };

                var aspUser = this.aspUsers.All
                    .First(u => u.Id == aspUserId);

                model.UserTweet.Add(new UserTweet()
                {
                    User = aspUser
                });

                this.tweets.Add(model);
            }

            this.saver.SaveChanges();
        }

        public void TakeFavouriteTweetsOfUser(string aspUserId)
        {

        }

        public void RemoveTweet(string tweetId, string aspUserId)
        {

        }
    }
}

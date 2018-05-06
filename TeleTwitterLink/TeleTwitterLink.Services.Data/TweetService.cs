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

        public TweetService(ISaver saver, IRepository<Tweet> tweets)
        {
            this.saver = saver;
            this.tweets = tweets;
        }

        public void SaveTweet(TweetDTO dto, string aspUserId)
        {

        }

        public void TakeFavouriteTweetsOfUser(string aspUserId)
        {

        }

        public void RemoveTweet(string tweetId, string aspUserId)
        {

        }
    }
}

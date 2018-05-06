using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITweetService
    {
        void SaveTweet(TweetDTO dto, string aspUserId);

        void TakeFavouriteTweetsOfUser(string aspUserId);

        void RemoveTweet(string tweetId, string aspUserId);
    }
}

using System.Collections.Generic;
using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITweetService
    {
        void SaveTweet(TweetDTO dto, string aspUserId);

        IList<TweetDTO> TakeFavouriteTweetsOfUser(string aspUserId);

        void RemoveTweet(string tweetId, string aspUserId);
    }
}

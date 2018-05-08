using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITwitterApiService
    {
        TwitterUserDTO[] FindTwitterUserByName(string name);

        TweetDTO[] GetTweetsOfUser(string screenName);

        TwitterUserDTO FindTwitterUserByTwitterId(string id);

        TweetDTO GetTweetById(string tweetId);
    }
}

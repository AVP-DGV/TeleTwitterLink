using Newtonsoft.Json.Linq;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class TwitterApiService : ITwitterApiService
    {
        private IDeserializerOfJson jsonDeserializer;
        private ITwitterApi apiCall;

        public TwitterApiService(IDeserializerOfJson jsonDeserializer, ITwitterApi apiCall)
        {
            this.jsonDeserializer = jsonDeserializer;
            this.apiCall = apiCall;
        }

        public TwitterUserDTO[] FindTwitterUserByName(string name)
        {
            var search = "https://api.twitter.com/1.1/users/search.json?q=";
            var foundUsers = this.apiCall.GetData(search + name.Trim());
            var deserializedUsers = this.jsonDeserializer.DeserializeJson<TwitterUserDTO[]>(foundUsers);

            return deserializedUsers;
        }

        public TwitterUserDTO FindTwitterUserByTwitterId(string id)
        {
            var searchString = "https://api.twitter.com/1.1/users/show.json?user_id=" + id;
            var foundResult = this.apiCall.GetData(searchString);
            var desirializedTwitterUser = this.jsonDeserializer.DeserializeJson<TwitterUserDTO>(foundResult);

            return desirializedTwitterUser;
        }

        public TweetDTO[] GetTweetsOfUser(string twitterUserId)
        {
            var searchString = "https://api.twitter.com/1.1/statuses/user_timeline.json?user_id=";
            var additionalParams = "&exclude_replies=true&include_rts=true";
            var foundTweetsString = this.apiCall.GetData(searchString + twitterUserId + additionalParams);
            var desirializedTweets = this.jsonDeserializer.DeserializeJson<TweetDTO[]>(foundTweetsString);

            return desirializedTweets;
        }

        public TweetDTO GetTweetById(string tweetId)
        {
            var searchedString = "https://api.twitter.com/1.1/statuses/show.json?id=";
            var foundTweetString = this.apiCall.GetData(searchedString + tweetId);
            JObject json = JObject.Parse(foundTweetString);
            var twitterUserId = json["user"]["id_str"];
            var desirelizedTweet = this.jsonDeserializer.DeserializeJson<TweetDTO>(foundTweetString);
            desirelizedTweet.TwitterUserId = twitterUserId.ToString();

            return desirelizedTweet;
        }
    }
}

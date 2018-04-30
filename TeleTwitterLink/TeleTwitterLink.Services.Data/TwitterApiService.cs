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
<<<<<<< HEAD
        public void GetTweetsOfUser(string screenName)
        {
            var searchString = "https://api.twitter.com/1.1/statuses/user_timeline.json?from:screen_name=BarackObama+AND+from:screen_name=Dropbox";
            //screen_name=twitterapi&count=2
            //?q=from:user1+OR+from:user2
            var foundTweetsString = apiCall.GetData(searchString);
=======

        public void FindTweetsUserByName()
        {
            var search = "https://api.twitter.com/1.1/tweets.json?q=Dropbox";
            var foundUsers = this.apiCall.GetData(search);
            //var deserializedUsers = this.jsonDeserializer.DeserializeJson<TwitterUserDTO[]>(foundUsers);

            ////return deserializedTweets;
>>>>>>> d9d8e17d594fbd29710f48e77bd69821848a5a99
        }
    }
}

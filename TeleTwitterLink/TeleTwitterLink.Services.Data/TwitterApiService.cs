using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class TwitterApiService : ITwitterApiService
    {
        private ITwitterApiCall apiCall;
        private IJsonDeserializer jsonDeserializer;

        public TwitterApiService(ITwitterApiCall apiCall, IJsonDeserializer jsonDeserializer)
        {
            this.apiCall = apiCall;
            this.jsonDeserializer = jsonDeserializer;
        }

        public TwitterUserDTO[] FindTwitterUserByName(string name)
        {
            var searchString = "https://api.twitter.com/1.1/users/search.json?q=";
            var foundUsersString = apiCall.GetTwitterData(searchString + name.Trim());
            var deserializedUsers = this.jsonDeserializer.Deserialize<TwitterUserDTO[]>(foundUsersString);

            return deserializedUsers;
        }
    }
}

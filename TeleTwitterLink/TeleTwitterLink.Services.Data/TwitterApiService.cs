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
    }
}

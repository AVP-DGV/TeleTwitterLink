using Newtonsoft.Json;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class JsonDeserializer : IJsonDeserializer
    {
        public T Deserialize<T>(string jsonString)
        {
            T objects = JsonConvert.DeserializeObject<T>(jsonString);

            return objects;
        }
    }
}

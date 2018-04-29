using Newtonsoft.Json;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class DeserializerOfJson : IDeserializerOfJson
    {
        public T DeserializeJson<T>(string json)
        {
            T convertedJsons = JsonConvert.DeserializeObject<T>(json);

            return convertedJsons;
        }
    }
}

using Newtonsoft.Json;
using System;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class DeserializerOfJson : IDeserializerOfJson
    {
        public T DeserializeJson<T>(string json)
        {
            if (json == "")
            {
                throw new ArgumentException("Json cannot be empty!");
            }

            T convertedJsons = JsonConvert.DeserializeObject<T>(json);

            return convertedJsons;
        }
    }
}

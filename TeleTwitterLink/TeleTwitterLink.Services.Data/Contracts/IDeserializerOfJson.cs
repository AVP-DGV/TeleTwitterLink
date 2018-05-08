namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IDeserializerOfJson
    {
        T DeserializeJson<T>(string json);
    }
}

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IJsonDeserializer
    {
        T Deserialize<T>(string jsonString);
    }
}

namespace TeleTwitterLink.Services.Data
{
    public interface ITwitterKeys
    {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
        string AccessToken { get; }
        string AccessSecret { get; }
    }
}
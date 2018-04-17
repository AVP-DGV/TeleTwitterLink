namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITwitterApiCall
    {
        string GetTwitterData(string resourceurl);
    }
}
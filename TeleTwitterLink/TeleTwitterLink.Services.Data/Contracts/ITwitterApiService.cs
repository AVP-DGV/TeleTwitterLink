using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITwitterApiService
    {
        TweeterUserDTO[] FindTwitterUserByName(string name);
    }
}

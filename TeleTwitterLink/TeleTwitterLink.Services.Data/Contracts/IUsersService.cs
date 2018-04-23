using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IUsersService
    {
        void AddUser(TweeterUserDTO dto);
    }
}
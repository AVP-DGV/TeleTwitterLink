using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IUsersService
    {
        void AddUser(TwitterUserDTO dto, string aspUserId);
    }
}
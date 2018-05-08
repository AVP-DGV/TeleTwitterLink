using System.Collections.Generic;
using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IUserService
    {
        void AddUser(TwitterUserDTO dto, string aspUserId);

        IList<TwitterUserDTO> TakeFavouriteTwitterUsers(string aspUserId);

        IList<TwitterUserDTO> FilterSearchReault(IList<TwitterUserDTO> searchResult, string aspUserId);

        void RemoveTwitterUser(string twitterUserId, string aspUserId);
    }
}
using System.Collections.Generic;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IUsersService
    {
        void AddUser(TwitterUserDTO dto, string aspUserId);

        IList<TwitterUserDTO> TakeFavouriteTwitterUsers(string aspUserId);

        IList<TwitterUserDTO> FilterSearchReault(IList<TwitterUserDTO> searchResult, string aspUserId);
    }
}
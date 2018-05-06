using System;
using System.Collections.Generic;
using System.Text;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface IUserManagerService
    {
        IList<UserDTO> GetAllUsers();
    }
}

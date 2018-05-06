using System;
using System.Collections.Generic;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLInk.Data.Repository;

namespace TeleTwitterLink.Services.Data
{
    public class UserManagerService : IUserManagerService
    {
        private IRepository<User> users;

        public UserManagerService(IRepository<User> users)
        {
            this.users = users;
        }

        public IList<UserDTO> GetAllUsers()
        {
            var users = this.users.All
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    TestName = x.TestName,
                    UserTweet = x.UserTweet,
                    UserTwitterUsers = x.UserTwitterUsers
                })
                .ToList();

            return users;
        }
    }
}

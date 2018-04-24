using System.Collections.Generic;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;

namespace TeleTwitterLink.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly ISaver saver;
        private readonly IRepository<TwitterUser> users;
        private readonly IRepository<User> aspUsers;
        private readonly IRepository<UserTwitterUser> userTwitterUsers;

        public UsersService(ISaver saver, IRepository<TwitterUser> users, IRepository<User> aspUsers, IRepository<UserTwitterUser> usersTwitterUsers)
        {
            this.saver = saver;
            this.users = users;
            this.aspUsers = aspUsers;
            this.userTwitterUsers = usersTwitterUsers;
        }

        public void AddUser(TwitterUserDTO dto, string aspUserId)
        {
            var model = new TwitterUser
            {
                TweeterUserId = dto.TweeterUserId,
                Name = dto.Name,
                FollowersCount = dto.FollowersCount,
                FriendsCount = dto.FriendsCount,
                Location = dto.Location,
                ImgUrl = dto.Location,
                Description = dto.Description,
                UserTwitterUsers = new List<UserTwitterUser>()
            };
            
            User aspUser = this.aspUsers.All
                .FirstOrDefault(u => u.Id == aspUserId);

            model.UserTwitterUsers.Add(new UserTwitterUser()
            {
                User = aspUser
            });

            this.users.Add(model);
            
            this.saver.SaveChanges();
        }
    }
}


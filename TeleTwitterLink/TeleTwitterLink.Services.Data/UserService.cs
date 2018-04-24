using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Infrastructure.Providers;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;

namespace TeleTwitterLink.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly ISaver saver;
        private readonly IRepository<TwitterUser> users;

        public UsersService(ISaver saver, IRepository<TwitterUser> users)
        {
            this.saver = saver;
            this.users = users;
        }

        public void AddUser(TwitterUserDTO dto)
        {
            var model = new TwitterUser
            {
                TweeterUserId = dto.TweeterUserId,
                Name = dto.Name,
                FollowersCount = dto.FollowersCount,
                FriendsCount = dto.FriendsCount,
                Location = dto.Location,
                ImgUrl = dto.Location,
                Description = dto.Description
            };

            this.users.Add(model);
            this.saver.SaveChanges();
        }
    }
}

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
        private readonly IRepository<TwitterUser> twitteUsers;
        private readonly IRepository<User> aspUsers;
        private readonly IRepository<UserTwitterUser> userTwitterUsers;

        public UsersService(ISaver saver, IRepository<TwitterUser> twitterUsers, IRepository<User> aspUsers, IRepository<UserTwitterUser> usersTwitterUsers)
        {
            this.saver = saver;
            this.twitteUsers = twitterUsers;
            this.aspUsers = aspUsers;
            this.userTwitterUsers = usersTwitterUsers;
        }

        public void AddUser(TwitterUserDTO dto, string aspUserId)
        {
            var model = new TwitterUser
            {
                TweeterUserId = dto.TwitterUserId,
                Name = dto.Name,
                FollowersCount = dto.FollowersCount,
                FriendsCount = dto.FriendsCount,
                Location = dto.Location,
                ImgUrl = dto.ImgUrl,
                Description = dto.Description,
                UserTwitterUsers = new List<UserTwitterUser>()
            };

            User aspUser = this.aspUsers.All
                .FirstOrDefault(u => u.Id == aspUserId);

            model.UserTwitterUsers.Add(new UserTwitterUser()
            {
                User = aspUser
            });

            this.twitteUsers.Add(model);

            this.saver.SaveChanges();
        }

        public IList<TwitterUserDTO> TakeFavouriteTwitterUsers(string aspUserId)
        {
            var twitterUsersIds = this.userTwitterUsers.All
                .Where(x => x.UserId == aspUserId)
                .Select(x => x.TwitterUserId)
                .ToList();

            var twitterUsers = this.twitteUsers.All
                .Where(x => twitterUsersIds.Contains(x.Id))
                .Select(x => new TwitterUserDTO()
                {
                    Description = x.Description,
                    FollowersCount = x.FollowersCount,
                    FriendsCount = x.FriendsCount,
                    ImgUrl = x.ImgUrl,
                    Location = x.Location,
                    Name = x.Name,
                    TwitterUserId = x.TweeterUserId
                })
                .ToList();

            return twitterUsers;
        }

        public IList<TwitterUserDTO> FilterSearchReault(IList<TwitterUserDTO> searchResult, string aspUserId)
        {
            var favouriteTwitterUserIds = this.TakeFavouriteTwitterUsers(aspUserId)
                .Select(x => x.TwitterUserId)
                .ToList();
            
            for (int i = 0; i < searchResult.Count(); i++)
            {
                if(favouriteTwitterUserIds.Contains(searchResult[i].TwitterUserId))
                {
                    searchResult[i].IsSaved = true;
                }
            }
            
            return searchResult;
        }

        public void RemoveTwitterUser(string twitterUserId)
        {
            var idInDB = this.twitteUsers.All
                  .First(x => x.TweeterUserId == twitterUserId).Id;

            this.userTwitterUsers.All
                .First(x => x.TwitterUserId == idInDB)
                .IsDeleted = true;

            this.saver.SaveChanges();
        }
    }
}


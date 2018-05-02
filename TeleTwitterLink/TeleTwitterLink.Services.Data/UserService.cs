using System;
using System.Collections.Generic;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLInk.Data.Repository;
using TeleTwitterLInk.Data.Saver;

namespace TeleTwitterLink.Services.Data
{
    public class UserService : IUserService
    {
        private readonly ISaver saver;
        private readonly IRepository<TwitterUser> twitterUsers;
        private readonly IRepository<User> aspUsers;
        private readonly IRepository<UserTwitterUser> userTwitterUsers;

        public UserService(ISaver saver, IRepository<TwitterUser> twitterUsers, IRepository<User> aspUsers, IRepository<UserTwitterUser> usersTwitterUsers)
        {
            this.saver = saver ?? throw new ArgumentNullException();
            this.twitterUsers = twitterUsers ?? throw new ArgumentNullException();
            this.aspUsers = aspUsers ?? throw new ArgumentNullException();
            this.userTwitterUsers = usersTwitterUsers ?? throw new ArgumentNullException();
        }

        public void AddUser(TwitterUserDTO dto, string aspUserId)
        {
            if (aspUserId == null)
            {
                throw new ArgumentNullException("UserId cannot be null!");
            }

            if (aspUserId == string.Empty)
            {
                throw new ArgumentException("UserId cannot be empty!");
            }

            if (dto == null)
            {
                throw new ArgumentNullException("TwitterUser cannot be null!");
            }

            var addedUser = this.twitterUsers.All
                 .FirstOrDefault(x => x.TwitterUserId == dto.TwitterUserId);

            if (addedUser != null)
            {
                this.userTwitterUsers.AllAndDeleted
                    .FirstOrDefault(x => x.TwitterUserId == addedUser.Id)
                    .IsDeleted = false;

                this.saver.SaveChanges();
            }
            else
            {
                var model = new TwitterUser
                {
                    TwitterUserId = dto.TwitterUserId,
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

                this.twitterUsers.Add(model);

                this.saver.SaveChanges();
            }
        }

        public IList<TwitterUserDTO> TakeFavouriteTwitterUsers(string aspUserId)
        {
            var twitterUsersIds = this.userTwitterUsers.All
                .Where(x => x.UserId == aspUserId)
                .Select(x => x.TwitterUserId)
                .ToList();

            var twitterUsers = this.twitterUsers.All
                .Where(x => twitterUsersIds.Contains(x.Id))
                .Select(x => new TwitterUserDTO()
                {
                    Description = x.Description,
                    FollowersCount = x.FollowersCount,
                    FriendsCount = x.FriendsCount,
                    ImgUrl = x.ImgUrl,
                    Location = x.Location,
                    Name = x.Name,
                    TwitterUserId = x.TwitterUserId
                })
                .ToList();

            return twitterUsers;
        }

        public IList<TwitterUserDTO> FilterSearchReault(IList<TwitterUserDTO> searchResult, string aspUserId)
        {
            var favouriteTwitterUserIds = this.TakeFavouriteTwitterUsers(aspUserId)
                .Select(x => x.TwitterUserId)
                .ToList();

            if (favouriteTwitterUserIds.Count != 0)
            {
                for (int i = 0; i < searchResult.Count(); i++)
                {
                    if (favouriteTwitterUserIds.Contains(searchResult[i].TwitterUserId))
                    {
                        searchResult[i].IsSaved = true;
                    }
                }
            }

            return searchResult;
        }

        public void RemoveTwitterUser(string twitterUserId)
        {
            var idInDB = this.twitterUsers.All
                  .First(x => x.TwitterUserId == twitterUserId).Id;

            this.userTwitterUsers.All
                .First(x => x.TwitterUserId == idInDB)
                .IsDeleted = true;

            this.saver.SaveChanges();
        }
    }
}


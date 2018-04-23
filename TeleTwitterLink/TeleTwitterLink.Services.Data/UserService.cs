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
        private readonly IMappingProvider mapper;
        private readonly IRepository<TweeterUser> users;

        public UsersService(ISaver saver, IMappingProvider mapper, IRepository<TweeterUser> users)
        {
            this.saver = saver;
            this.mapper = mapper;
            this.users = users;
        }

        public void AddUser(TweeterUserDTO dto)
        {
            var model = this.mapper.MapTo<TweeterUser>(dto);
            this.users.Add(model);
            this.saver.SaveChanges();
        }
    }
}

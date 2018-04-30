using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITwitterApiService
    {
        TwitterUserDTO[] FindTwitterUserByName(string name);

<<<<<<< HEAD
        void GetTweetsOfUser(string screenName);
=======
        void FindTweetsUserByName();
>>>>>>> d9d8e17d594fbd29710f48e77bd69821848a5a99
    }
}

using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Services.Data.Contracts
{
    public interface ITwitterApiService
    {
        TwitterUserDTO[] FindTwitterUserByName(string name);
        
        void GetTweetsOfUser(string screenName);

        void FindTweetsUserByName();
    }
}

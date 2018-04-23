using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLink.Data.Models
{
    public class TweeterUser : DataModel
    {
        public string TweeterUserId { get; set; }

        public string Name { get; set; }

        public int FollowersCount { get; set; }

        public int FriendsCount { get; set; }

        public string Location { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }
    }
}

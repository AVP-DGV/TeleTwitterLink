using System;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLink.Data.Models
{
    public class UserTweet : IDeletable
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int TweetId { get; set; }
        public Tweet Tweet { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

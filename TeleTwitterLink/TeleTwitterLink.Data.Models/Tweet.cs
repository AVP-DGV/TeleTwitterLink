using System;
using System.Collections.Generic;
using System.Text;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLink.Data.Models
{
    public class Tweet : DataModel
    {
        public string CreatedAt { get; set; }

        public string TweetId { get; set; }

        public string Text { get; set; }

        public int TwitterUserId { get; set; }
        public TwitterUser TwitterUser { get; set; }

        public ICollection<UserTweet> UserTweet { get; set; }
    }
}

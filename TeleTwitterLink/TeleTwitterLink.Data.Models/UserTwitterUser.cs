using System;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLink.Data.Models
{
    public class UserTwitterUser : IDeletable
    {
        public int TwitterUserId { get; set; }
        public TwitterUser TwitterUser { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}

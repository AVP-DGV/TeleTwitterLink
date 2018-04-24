using System;
using System.Collections.Generic;
using System.Text;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLink.Data.Models
{
    public class UserTwitterUser : DataModel
    {
        public int TwitterUserId { get; set; }
        public TwitterUser TwitterUser { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}

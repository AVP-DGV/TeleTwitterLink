using System;
using System.Collections.Generic;
using TeleTwitterLink.Data.Models;

namespace TeleTwitterLink.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string TestName { get; set; }
        
        public DateTime? DeletedOn { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        
        public DateTime? ModifiedOn { get; set; }

        public ICollection<UserTwitterUser> UserTwitterUsers { get; set; }

        public ICollection<UserTweet> UserTweet { get; set; }
    }
}

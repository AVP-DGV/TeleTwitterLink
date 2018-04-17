using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeleTwitterLink.DTO
{
    public class TweeterUserDTO
    {
        [JsonProperty("id_str")]
        public string TweeterUserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }
    }
}

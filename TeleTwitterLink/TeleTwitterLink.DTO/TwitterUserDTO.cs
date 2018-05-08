using Newtonsoft.Json;
using System;

namespace TeleTwitterLink.DTO
{
    public class TwitterUserDTO
    {
        [JsonProperty("id_str")]
        public string TwitterUserId { get; set; }

        [JsonProperty("screen_name")]
        public string Name { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("profile_image_url_https")]
        public string ImgUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public DateTime? CretedOn { get; set; }

        public UserDTO User { get; set; }

        public bool IsSaved { get; set; }
    }
}

using Newtonsoft.Json;

namespace TeleTwitterLink.DTO
{
    public class TweetDTO
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("id_str")]
        public string TweetId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        public string TwitterUserId { get; set; }

        public TwitterUserDTO TwitterUser { get; set; }

        public bool IsSaved { get; set; }

        public string GetFormattedTime()
        {
            var parts = this.CreatedAt.Split();

            return $"{parts[1]} {parts[2]}, {parts[3]}";
        }
    }
}

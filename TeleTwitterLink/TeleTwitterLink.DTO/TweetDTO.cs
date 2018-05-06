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

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
    }
}

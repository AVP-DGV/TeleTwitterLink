using Newtonsoft.Json;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Text;
=======
>>>>>>> e1b0c85ab7ddcd8159952c649b8bceef2f22b38c

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
    }
}

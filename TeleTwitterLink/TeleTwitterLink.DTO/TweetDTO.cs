using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeleTwitterLink.DTO
{
    public class TweetDTO
    {
        //public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //public string Content { get; set; }

        //public string AuthorId { get; set; }

        //public UserDTO Author { get; set; }
    }
}

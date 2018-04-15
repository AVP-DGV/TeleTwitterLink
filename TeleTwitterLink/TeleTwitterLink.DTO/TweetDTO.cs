﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeleTwitterLink.DTO
{
    public class TweetDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public UserDTO Author { get; set; }
    }
}
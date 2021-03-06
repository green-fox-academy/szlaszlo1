﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Upvote { get; set; }
        public int DownVote { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

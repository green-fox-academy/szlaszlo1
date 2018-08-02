using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long TimeStamp { get; set; }
        [DefaultValue(0)]
        public int Score { get; set; }
        public virtual User Owner { get; set; }
        public int? UserId { get; set; }
    }
}

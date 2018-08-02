using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Models
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long TimeStamp { get; set; }
        public int Score { get; set; }
        public string Owner { get; set; }
        public void SetOwner(User owner)
        {
            if (owner == null)
            {
                Owner = null;
            }
            else
            {
                Owner = owner.UserName;
            }
        }
    }
}

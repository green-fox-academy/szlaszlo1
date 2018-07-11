using RedditBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Repositories
{
    public class PostRepository
    {
        RedditContext redditContext;
        public PostRepository(RedditContext redditContext)
        {
            this.redditContext = redditContext;
        }
        public List<Post> GetPosts()
        {
            return redditContext.Posts.ToList();

        }
    }
}

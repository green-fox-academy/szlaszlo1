using RedditBackend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<Post> ReadAllPosts()
        {
            return redditContext.Posts.ToList();

        }
        public Post CreatePost(Post post)
        {
            post.TimeStamp=Stopwatch.GetTimestamp();
            redditContext.Posts.Add(post);
            redditContext.SaveChanges();
            return  ReadPost(post.Id);
        }
        public Post ReadPost(int id)
        {
            return redditContext.Posts.FirstOrDefault(x => x.Id == id);
        }
        public void Update(Post post)
        {
            redditContext.Posts.Update(post);
            redditContext.SaveChanges();
        }
    }
}

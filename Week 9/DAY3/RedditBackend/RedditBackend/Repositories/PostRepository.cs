using Microsoft.EntityFrameworkCore;
using RedditBackend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Repositories
{
    public class PostRepository:IRedditRepository<Post>
    {
        RedditContext redditContext;
        public PostRepository(RedditContext redditContext)
        {
            this.redditContext = redditContext;
        }
        public List<Post> ReadAll()
        {
            return redditContext.Posts.Include(x=>x.Owner).ToList();

        }
        public Post Create(Post post)
        {
            redditContext.Posts.Add(post);
            redditContext.SaveChanges();
            return  Read(post.Id);
        }
        public Post Read(int id)
        {
            return redditContext.Posts.Include(x=>x.Owner).FirstOrDefault(x => x.Id == id);
        }
        public void Update(Post post)
        {
            redditContext.Posts.Update(post);
            redditContext.SaveChanges();
        }

        public void Delete(Post post)
        {
            redditContext.Posts.Remove(post);
            redditContext.SaveChanges();
        }
    }
}

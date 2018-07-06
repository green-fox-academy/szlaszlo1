using Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Repositories
{
    public class PostRepository : IRedditRepository<Post>
    {
        RedditContext redditContext;
        public PostRepository(RedditContext redditContext)
        {
            this.redditContext = redditContext;
        }
        public void Create(Post t)
        {
            redditContext.Posts.Add(t);
            redditContext.SaveChanges();
        }

        public void Delete(Post t)
        {
            redditContext.Posts.Remove(t);
            redditContext.SaveChanges();
        }

        public List<Post> GetAll()
        {
            return redditContext.Posts.ToList();
        }

        public Post GetElement(int i)
        {
            return redditContext.Posts.FirstOrDefault(x => x.Id == i);
        }

        public void Update(Post t)
        {
            redditContext.Update(t);
            redditContext.SaveChanges();
        }
    }
}

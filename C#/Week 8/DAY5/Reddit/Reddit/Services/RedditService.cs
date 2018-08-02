using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reddit.Models;
using Reddit.Repositories;

namespace Reddit.Services
{
    public class RedditService : IRedditService
    {
        PostRepository redditrepo;
        public RedditService(PostRepository redditrepo)
        {
            this.redditrepo = redditrepo;
        }
        public void AddNew(Post p)
        {
            p.CreatedAt = DateTime.Now;
            redditrepo.Create(p);
        }


        public Post GetPost(int id)
        {
            return redditrepo.GetElement(id);
        }

        public List<Post> GetPosts()
        {
            return redditrepo.GetAll();
        }

        public void Remove(Post p)
        {
            redditrepo.Delete(p);
        }

        public void UpVote(int id)
        {
            redditrepo.GetElement(id).Upvote++;
            redditrepo.Update(redditrepo.GetElement(id));
        }
        public void DownVote(int id)
        {
            redditrepo.GetElement(id).DownVote++;
            redditrepo.Update(redditrepo.GetElement(id));
        }
    }
}

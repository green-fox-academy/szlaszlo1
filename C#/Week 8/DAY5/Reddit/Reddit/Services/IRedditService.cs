using Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Services
{
    public interface IRedditService
    {
        void AddNew(Post p);
        List<Post> GetPosts();
        Post GetPost(int id);
        void Remove(Post p);
        void UpVote(int id);
        void DownVote(int id);
    }
}

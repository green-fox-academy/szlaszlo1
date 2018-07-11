using RedditBackend.Models;
using RedditBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Services
{
    public class PostService
    {
        PostRepository postrepo;
        public PostService(PostRepository postrepo)
        {
            this.postrepo = postrepo;
        }
        public List<Post> GetPosts()
        {
            return postrepo.ReadAllPosts();
        }
        public Post AddPost(Post post)
        {
            return postrepo.CreatePost(post);
        }
        public Post Upvote(int id)
        {
            postrepo.ReadPost(id).Score += 1;
            postrepo.Update(postrepo.ReadPost(id));
            return postrepo.ReadPost(id);
        }

        public Post Downvote(int id)
        {
            postrepo.ReadPost(id).Score -= 1;
            postrepo.Update(postrepo.ReadPost(id));
            return postrepo.ReadPost(id);
        }
    }
}

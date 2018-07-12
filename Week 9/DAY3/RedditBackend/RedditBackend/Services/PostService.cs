using RedditBackend.Models;
using RedditBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Services
{
    public class PostService
    {
        PostRepository postrepo;
        UserRepository userrepo;
        public PostService(PostRepository postrepo, UserRepository userrepo)
        {
            this.postrepo = postrepo;
            this.userrepo = userrepo;
        }
        public List<PostDTO> GetPosts()
        {
            List<Post> posts = postrepo.ReadAll();
            List<PostDTO> postdto = new List<PostDTO>();
            posts.ForEach(currentPost=>postdto.Add(new PostDTO(){ Id = currentPost.Id, Title = currentPost.Title, Url = currentPost.Url, TimeStamp = currentPost.TimeStamp, Score = currentPost.Score, }));
            posts.ForEach(p => { if (p.Owner==null) { postdto.First(dto => dto.Id == p.Id).Owner= null; } else { postdto.First(dto => dto.Id == p.Id).Owner = p.Owner.UserName; } });
            return postdto;
        }
        public Post AddPost(Post post,string user)
        {
            post.TimeStamp = Stopwatch.GetTimestamp(); 
            if (userrepo.Read(user) != null)
            {
                post.UserId = userrepo.Read(user).UserId;
            }
            else
            {
                post.Owner = null;
            }
            
            
            return postrepo.Create(post);

        }
        public Post Upvote(int id)
        {
            postrepo.Read(id).Score += 1;
            postrepo.Update(postrepo.Read(id));
            return postrepo.Read(id);
        }

        public Post Downvote(int id)
        {
            postrepo.Read(id).Score -= 1;
            postrepo.Update(postrepo.Read(id));
            return postrepo.Read(id);
        }
        public User AddUser(User user)
        {
            return userrepo.Create(user);
        }
    }
}

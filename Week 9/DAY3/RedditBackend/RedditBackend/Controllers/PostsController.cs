using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditBackend.Repositories;

namespace RedditBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        PostRepository postRepo;
        public PostsController(PostRepository postRepo)
        {
            this.postRepo = postRepo;
        }
    }
}
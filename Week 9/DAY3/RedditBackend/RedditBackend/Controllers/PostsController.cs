using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditBackend.Repositories;
using Newtonsoft.Json.Linq;
using RedditBackend.Models;
using RedditBackend.Services;

namespace RedditBackend.Controllers
{
    [Produces("application/json")]
    public class PostsController : Controller
    {
        PostService postSrv;
        public PostsController(PostService postSrv)
        {
            this.postSrv = postSrv;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return Content("anyád");
        }

        [HttpGet("/posts")]
        public IActionResult GetPosts()
        {
            return Json(new { posts = postSrv.GetPosts() });
        }

        [HttpPost("/posts")]
        public IActionResult AddNewPost([FromBody]Post newPost)
        {
            return Json(new {post=postSrv.AddPost(newPost) });
        }

        [HttpPut("/posts/{id}/upvote")]
        public IActionResult UpvotePost(int id)
        {
            return Json(postSrv.Upvote(id));
        }

        [HttpPut("/posts/{id}/downvote")]
        public IActionResult DownvotePost(int id)
        {
            return Json(postSrv.Downvote(id));
        }

        //[HttpDelete("/posts/{id}")]
        //public IActionResult Delete(int id)
        //{
            
        //}
    }
}
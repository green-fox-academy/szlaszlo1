using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reddit.Models;
using Reddit.Services;

namespace Reddit.Controllers
{
    [Route("")]
    public class RedditController : Controller
    {
        IRedditService redditsrv;
        public RedditController(IRedditService redditsrv)
        {
            this.redditsrv = redditsrv;
        }
        public IActionResult Index()
        {
            return View(redditsrv.GetPosts());
        }
        [HttpGet("{id}/upVote")]
        public IActionResult UpVote(int id)
        {
            redditsrv.UpVote(id);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}/downVote")]
        public IActionResult DownVote(int id)
        {
            redditsrv.DownVote(id);
            return RedirectToAction("Index");
        }
        [HttpGet("/submit")]
        public IActionResult Submit()
        {
            return View();
        }
        [HttpPost("/submit")]
        public IActionResult Submit(Post p)
        {
            redditsrv.AddNew(p);
            return RedirectToAction("Index");
        }
    }
}
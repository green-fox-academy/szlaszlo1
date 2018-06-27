using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreetSomeone.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreetSomeone.Controllers
{
    public class GreetingController : Controller
    {
        IGreetName greet;
        public GreetingController(IGreetName gn)
        {
            greet = gn;
        }


        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Index(string yourName)
        {
            greet.SetName(yourName);
            return RedirectToAction("greet");
        }

        [HttpGet("greet")]
        public IActionResult Greet()
        {
            
            return View("greet",greet.GetName());
        }
    }
}
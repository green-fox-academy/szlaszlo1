using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPD01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPD01.Controllers
{
    [Route("web")]
    public class WebController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Route("greeting")]
        public IActionResult Greeting(string yourName)
        {
            var greeting = new Greeting(yourName);
            return View(greeting);
        }
    }
}
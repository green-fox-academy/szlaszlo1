using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoxClub.Models;
using FoxClub.Services;

namespace FoxClub.Controllers
{
    public class HomeController : Controller
    {
        IFoxControll foxListControll;

        public HomeController(IFoxControll foxListControll)
        {
            this.foxListControll = foxListControll;
        }

        [HttpGet("/index")]
        public IActionResult Index(string name)
        {
            if (name == null && foxListControll.GetFox()==null) return RedirectToAction("Login", "Home", new { area = "" });
            else
            {
                foxListControll.AddFox(name);
                return View(foxListControll.GetFox());
            }
        }

        [Route("")]
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public IActionResult LoginWithName(string name)
        {
            foxListControll.AddFox(name);
            return RedirectToAction("Index");
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}

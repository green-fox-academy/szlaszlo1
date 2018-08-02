using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPD01.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPD01.Controllers
{
    [Route("api")]
    public class RESTController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("greeting")]
        public IActionResult Greeting(string yourName="Anonimous")
        {
            Greeting greeting = new Greeting(yourName);
            return new JsonResult(greeting);
        }
    }
}
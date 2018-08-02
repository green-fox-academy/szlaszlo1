using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anagramm.Services;
using Microsoft.AspNetCore.Mvc;

namespace Anagramm.Controllers
{
    public class AnagrammController : Controller
    {
        IAnagramChecker ac;

        public AnagrammController(IAnagramChecker ac)
        {
            this.ac = ac;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Result(string anagramm)
        {
            return View(ac.CheckForAnagramm(anagramm));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }



        [HttpGet("/doubling")]
        public IActionResult DoubleIng(int? input)
        {
            if (input != null)
            {
                return Json(new {received=input,result=input*2});
            }
            else
            {
                return Json(new { error = "Please provide an input!" });
            }
        }
    }
}
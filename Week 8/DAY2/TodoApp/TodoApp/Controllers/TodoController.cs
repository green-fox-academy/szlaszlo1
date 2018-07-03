using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    [Route("/todo")]
    public class TodoController : Controller
    {
        
        [Route("/")]
        [Route("/list")]
        public IActionResult List()
        {

            return Content("This is my first todo");
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
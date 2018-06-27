using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Counter2._0.Services;
using Microsoft.AspNetCore.Mvc;

namespace Counter2._0.Controllers
{
    public class CounterController : Controller
    {
        ICounter counter;
        public CounterController(ICounter counter)
        {
            this.counter = counter;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View(counter.GetNumber());
        }

        [HttpPost]
        [Route("/")]
        public IActionResult Count()
        {
            counter.Increase();
            return RedirectToAction("Index");

        }
    }
}
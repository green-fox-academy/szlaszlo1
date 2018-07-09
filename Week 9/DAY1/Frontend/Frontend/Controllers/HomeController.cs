using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

        [HttpGet("/greeter")]
        public IActionResult Greeter(string name,string title)
        {
            if (name== null)
            {
                return Json(new { error = "Please provide a name!" });
            }
            else if(title==null)
            {
                return Json(new { error = "Please provide a title!" });
            }
            else
            {
                return Json(new { welcome_message = "Oh, hi there " + name + ", my dear " + title + "!" });
            }
        }


        [HttpGet("/appenda/{appendable}")]
        public IActionResult AppendA(string appendable)
        {
            return Json(new { appended = appendable+"a" });
        }


        [HttpPost("/dountil/{what}")]
        public IActionResult DoUntil(string what,[FromBody]Until until)
        {
            if (until != null && until.until != null && until.until < 10)
            {
                if (what == "sum")
                {

                    for (int i = Convert.ToInt32(until.until) - 1; i > 0; i--)
                    {
                        until.until += i;
                    }
                    return Json(new { result = until.until });
                }
                else if (what == "factor")
                {

                    for (int i = Convert.ToInt32(until.until) - 1; i > 1; i--)
                    {
                        until.until *= i;
                    }
                    return Json(new { result = until.until });
                }
            }
            //else if(until==null || until.until==null)
            //{
            //    return Json(new { error = "Please provide a number!" });
            //}
            //else
            //{
            //    return Json(new { error = "Please provide a number!" });
            //}

            return Json(new { error = "Please provide a number!" });
        }

        [HttpPost("/arrays")]
        public IActionResult Arrays([FromBody]Arrays a)
        {
            if (a.Numbers!=null && a.Numbers.Length > 0)
            {
                switch (a.What)
                {
                    case "sum":
                        int sum = 0;
                        foreach (int item in a.Numbers)
                        {
                            sum += item;
                        }
                        return Json(new { result = sum });
                    case "multiply":
                        int multiply = 1;
                        foreach (int item in a.Numbers)
                        {
                            multiply *= item;
                        }
                        return Json(new { result = multiply });
                    case "double":
                        for (int i = 0; i < a.Numbers.Length; i++)
                        {
                            a.Numbers[i] *= 2;
                        }
                        return Json(new { result = a.Numbers });
                    default:
                        return Json(new { error = "Please provide what to do with the numbers!" });
                }
            }
            else
            {
                return Json(new { error = "Please provide numbers!" });
            }
        }
    }
}
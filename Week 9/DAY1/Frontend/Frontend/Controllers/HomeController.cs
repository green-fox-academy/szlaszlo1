using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Frontend.Controllers
{
    
    public class HomeController : Controller
    {
        ILogService logsrv;
        public HomeController(ILogService logsrv)
        {
            this.logsrv = logsrv;
        }


        [HttpGet("/")]
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }



        [HttpGet("/doubling")]
        public IActionResult DoubleIng(int? input)
        {
            logsrv.AddNew("/doubling", "input"+input.ToString());
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
            logsrv.AddNew("/greeter","name"+ name + ";" +"title="+ title);
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
            logsrv.AddNew("/appenda","appendable="+ appendable);
            return Json(new { appended = appendable+"a" });
        }


        [HttpPost("/dountil/{what}")]
        public IActionResult DoUntil(string what,[FromBody]Until until)
        {
            
            if (until != null && until.until != null && until.until < 10)
            {
                logsrv.AddNew("/dountil", "what=" + what + "until=" + until.ToString());
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
            else
            {
                logsrv.AddNew("/dountil", "what=" + what + "until=NULL");
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
            logsrv.AddNew("/arrays", "input="+a.ToString());
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

        [HttpGet("/log")]
        public IActionResult Log()
        {
            return Json(new {entries=logsrv.GetAll(), entry_count=logsrv.GetAll().Count });
        }

        [HttpPost("/sith")]
        public IActionResult Sith([FromBody]SithText text)
        {
            text.Text=text.Text.Substring(0,text.Text.Length-1)
            string[] sentences = text.Text.Split(".");
            for (int i=0;i<sentences.Length;i++)
            {
                if(sentences[i].StartsWith(' '))
                {
                    sentences[i] = sentences[i].Substring(1);
                }
                string[] words = sentences[i].Split(" ");
                string temps = "";
                for (int j = 0; j < words.Length; j=j+2)
                {
                    if (j + 1 < words.Length)
                    {
                        if (j==0)
                        {
                            words[j] = words[j].ToLower();
                            words[j + 1] = words[j + 1].Substring(0, 1).ToUpper() + words[j + 1].Substring(1);
                        }
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
                for (int f = 0; f < words.Length; f++)
                {
                    if (f+1>=words.Length)
                    {
                        temps += words[f] + ".";
                    }
                    else
                    {
                        temps += words[f] + " ";
                    }
                }
                sentences[i] = temps;
            }
            Random rnd = new Random();
            string[] rndString = new string[] { " Arrgh.", " Uhmm.", " Err...err.err." };
            string sith_string="";
            for (int i = 0; i < sentences.Length; i++)
            {
                int rndNum=rnd.Next(1, 3);
                if(i>0)
                    sith_string +=' ';
                sith_string += sentences[i];
                for (int k = 0; k < rndNum; k++)
                {
                    sith_string += rndString[rnd.Next(3)];
                }
            }
            return Json(new { sith_text=sith_string });
           
        }
    }
}
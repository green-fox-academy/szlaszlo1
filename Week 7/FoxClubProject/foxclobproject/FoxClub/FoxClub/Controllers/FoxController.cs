using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoxClub.Models;
using FoxClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoxClub.Controllers
{
    public class FoxController : Controller
    {
        IFoxControll foxListControll;
        public FoxController(IFoxControll foxListControll)
        {
            this.foxListControll = foxListControll;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/nutritionStore")]
        public IActionResult NutritionStore(string kaja,int portkaja, string pia,int portpia)
        {
            foxListControll.SetFood(kaja,portkaja);
            foxListControll.SetDrink(pia,portpia);
            return RedirectToAction("Index", "Home",new { area=""});
        }

        [HttpGet("/nutritionStore")]
        public IActionResult GetNutrition()
        {
            if (foxListControll.GetFox() == null) return RedirectToAction("Login", "Home", new { area = "" });
            else return View("NutritionStore", foxListControll.GetNutritionList());
        }
        [HttpPost("/newNutrition")]
        public IActionResult NewNutrition(Nutrition nut)
        {
            foxListControll.NewNutriotion(nut);
            return RedirectToAction("NutritionStore");
        }

        [Route("/trickCenter")]
        public IActionResult TrickCenter()
        {
            if (foxListControll.GetFox() == null) return RedirectToAction("Login", "Home", new { area = "" });
            else return View(foxListControll.ShowPossibleTricks());
        }

        [HttpPost("/trickCenter")]
        public IActionResult TrickLearning(string trick)
        {
            foxListControll.LearnTrick(trick);
            return RedirectToAction("Index", "Home",new { area = "" });
        }

        [HttpGet("/actionHistory")]
        public IActionResult ActionHistory()
        {
            if (foxListControll.GetFox() == null) return RedirectToAction("Login", "Home", new { area = "" });
            else return View(foxListControll.GetActionHistory());
        }

    }
}
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
        public IActionResult NutritionStore(string kaja, string pia)
        {
            foxListControll.SetFood(kaja);
            foxListControll.SetDrink(pia);
            return RedirectToAction("Index", "Home",new { area=""});
        }

        [HttpGet("/nutritionStore")]
        public IActionResult GetNutrition()
        {
            return View("NutritionStore", foxListControll.GetNutritionList());
        }
        [HttpPost("/newNutrition")]
        public IActionResult NewNutrition(Nutrition nut)
        {
            foxListControll.NewNutriotion(nut);
            return RedirectToAction("NutritionStore");
        }
    }
}
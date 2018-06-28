using FoxClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Services
{
    public interface IFoxControll
    {
        void AddFox(string name);
        Fox GetFox();

        void SetFood(string kaja);
        void SetDrink(string pia);
        List<Nutrition> GetNutritionList();
        void NewNutriotion(Nutrition name);
    }
}

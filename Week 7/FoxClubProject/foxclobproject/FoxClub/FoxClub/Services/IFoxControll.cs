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
        
        void SetFood(string kaja, int portkaja);
        void SetDrink(string pia, int portpia);
        List<Nutrition> GetNutritionList();
        void NewNutriotion(Nutrition name);
        void LearnTrick(string trick);
        void SelectTrick(string trick);
        List<string> ShowPossibleTricks();

        Stack<string> GetActionHistory();

        void ReduceNutrition();
        void CheckAlive();
    }
}

using FoxClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Services
{
    public class FoxControll : IFoxControll
    {
        List<Fox> foxCollection = new List<Fox>();
        List<Nutrition> nutritionList = new List<Nutrition>();
        Fox currentFox;
        public void AddFox(string name)
        {
            if (name != null)
            {
                if (foxCollection.Where(x => x.Name == name).ToArray().Count() == 0)
                {
                    foxCollection.Add(new Fox { Name = name });
                    currentFox = foxCollection.Where(x => x.Name == name).ToArray()[0];
                }
                else
                {
                    currentFox = foxCollection.Where(x => x.Name == name).ToArray()[0];
                }
            }
        }

       

        public Fox GetFox()
        {
            return currentFox;
        }

        public List<Nutrition> GetNutritionList()
        {
            return nutritionList;
        }

        public void NewNutriotion(Nutrition name)
        {
            nutritionList.Add(name);
        }

        public void SetDrink(string pia)
        {
            currentFox.Drink = pia;
        }

        public void SetFood(string kaja)
        {
            currentFox.Food = kaja;
        }
    }
}

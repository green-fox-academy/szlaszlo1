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
        List<string> tricks = new List<string>() {"write HTML", "Read from JSon", "Write to JSon" };
        Fox currentFox;
        public void AddFox(string name)
        {
            if (name != null)
            {
                if (foxCollection.Where(x => x.Name == name).ToArray().Count() == 0)
                {
                    foxCollection.Add(new Fox { Name = name });
                    currentFox = foxCollection.Where(x => x.Name == name).ToArray()[0];
                    currentFox.HistoryElement = new Stack<string>();
                    currentFox.HistoryElement.Push($"{DateTime.Now} : {currentFox.Name} was born");
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
            if (currentFox.Drink != pia)
            currentFox.HistoryElement.Push($"{DateTime.Now} : Drink has been changed from: {currentFox.Drink} to: {pia}");
            currentFox.Drink = pia;
        }

        public void SetFood(string kaja)
        {
            if (currentFox.Food != kaja)
                currentFox.HistoryElement.Push($"{DateTime.Now} : Food has been changed from: {currentFox.Food} to: {kaja}");
            currentFox.Food = kaja;
        }

        public List<string> ShowPossibleTricks()
        {
            if (currentFox.Tricks != null)
                return tricks.Except(currentFox.Tricks).ToList();
            else
                return tricks;
        }
        public void LearnTrick(string trick)
        {
            if (currentFox.Tricks == null)
                currentFox.Tricks = new List<string>();
            
            currentFox.HistoryElement.Push($"{DateTime.Now} : Learned to: {trick}");

            currentFox.Tricks.Add(trick);
        }

        public Stack<string> GetActionHistory()
        {
            return currentFox.HistoryElement;
        }
    }
}

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
        List<string> tricks = new List<string>() {"write HTML", "Read from JSon", "Write to JSon","Rabbit hunting","Thieving","Get Rabies" };
        Fox currentFox;
        public void AddFox(string name)
        {
            if (name != null)
            {
                if (foxCollection.Where(x => x.Name == name).ToArray().Count() == 0)
                {
                    foxCollection.Add(new Fox { Name = name,IsDead=false,Birth=DateTime.Now });
                    currentFox = foxCollection.Where(x => x.Name == name).ToArray()[0];
                    currentFox.HistoryElement = new Stack<string>();
                    currentFox.HistoryElement.Push($"{currentFox.Birth} : {currentFox.Name} was born");
                }
                else
                {
                    currentFox = foxCollection.Where(x => x.Name == name).ToArray()[0];
                }
                
               
            }
            if (!currentFox.IsDead)
            {
                ReduceNutrition();
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

        public void SetDrink(string pia, int portpia)
        {
            if (currentFox.Drink == null)
            {
                currentFox.Drink = new Nutrition();
                currentFox.HistoryElement.Push($"{DateTime.Now} : Drink has been changed from: {currentFox.Drink} to: {pia}, ({portpia} portion)");
            }
            else
            {
                if (currentFox.Drink.Name != pia)
                    currentFox.HistoryElement.Push($"{DateTime.Now} : Drink has been changed from: {currentFox.Drink} to: {pia}  ({portpia} portion)");
                else
                    currentFox.HistoryElement.Push($"{DateTime.Now} : Portion has been changed from: {currentFox.Drink.Portion} to: {pia}  ({portpia} portion)");
            }
            
            currentFox.Drink.Name = pia;
            currentFox.Drink.Portion = portpia;
            currentFox.Drink.AddedTime = DateTime.Now;
        }

        public void SetFood(string kaja,int portkaja)
        {
            if (currentFox.Food == null)
            {
                currentFox.Food = new Nutrition();
                currentFox.HistoryElement.Push($"{DateTime.Now} : Food has been changed to: {kaja}  ({portkaja} portion)");
            }
            else
            {
                if (currentFox.Food.Name != kaja)
                    currentFox.HistoryElement.Push($"{DateTime.Now} : Food has been changed from: {currentFox.Food.Name} to: {kaja}  ({portkaja} portion)");
                else
                    currentFox.HistoryElement.Push($"{DateTime.Now} : Portion has been changed from: {currentFox.Food.Portion} to: {kaja}  ({portkaja} portion)");
            }
            
            
            currentFox.Food.Name = kaja;
            currentFox.Food.Portion = portkaja;
            currentFox.Food.AddedTime = DateTime.Now;
        }

        public void ReduceNutrition()
        {
            if (currentFox.Food != null || currentFox.Drink != null)
            { 
            if (currentFox.Food != null)
                currentFox.Food.Portion -= (int)DateTime.Now.Subtract(currentFox.Food.AddedTime).TotalMinutes;
                
            if (currentFox.Drink != null && !currentFox.IsDead)
                currentFox.Drink.Portion -= (int)DateTime.Now.Subtract(currentFox.Drink.AddedTime).TotalMinutes;


                CheckAlive();
            }
            else
            {
                currentFox.IsDead = ((int)DateTime.Now.Subtract(currentFox.Birth).TotalMinutes >= 5) ? true : false;
            }
        }

        public void CheckAlive()
        {
            currentFox.IsDead = (currentFox.Drink.Portion <= 0 || currentFox.Food.Portion <= 0) ? true : false;

        }
        public List<string> ShowPossibleTricks()
        {
            if (currentFox != null)
            {
                if (currentFox.Tricks != null)
                    return tricks.Except(currentFox.Tricks).ToList();
                else
                    return tricks;
            }
            else
            {
                return tricks;
            }
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			 //Exercise 10
            Console.WriteLine("\nExercise 10");
            
            List<Fox> fox = new List<Fox>{
            new Fox("1","sdfsdf","Green"),
            new Fox("2", "pallida", "Green"),
            new Fox("3", "sdfsdf", "Yellow"),
            new Fox("4", "sdfsdf", "Red"),
            new Fox("5","sdfsdf","Black"),
            new Fox("6","sdfsdf","Blue"),
            new Fox("7","sdfsdf","Green")};
            //Query syntax
            Console.WriteLine("Query syntax");
            IEnumerable<Fox> filteredFox = from f in fox
                                           where f.Color == "Green"
                                           select f;
            IEnumerable<Fox> filteredFox2 = from f in fox
                                           where f.Color == "Green" && f.Type=="pallida"
                                           select f;
            foreach (Fox item in filteredFox)
            {
                Console.WriteLine($"Név:{item.Name}, type={item.Type},color:{item.Color}");
            }

            foreach (Fox item in filteredFox2)
            {
                Console.WriteLine($"Név:{item.Name}, type={item.Type},color:{item.Color}");
            }
            //Method syntax
            Console.WriteLine("Method syntax");
            IEnumerable<Fox> filteredFox3 = fox.Where(p => p.Color == "Green");
            filteredFox3.ToList().ForEach(f => Console.WriteLine("Név:{0} Típus:{1} Szín:{2}", f.Name, f.Type, f.Color));
            IEnumerable<Fox> filteredFox4 = fox.Where(p => p.Color == "Green" && p.Type=="pallida");
            filteredFox4.ToList().ForEach(f=>Console.WriteLine("Név:{0} Típus:{1} Szín:{2}",f.Name,f.Type,f.Color));
            Console.ReadKey();
		}


	}


}
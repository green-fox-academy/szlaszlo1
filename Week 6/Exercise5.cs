using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			//Exercise 5
           		int[] e5 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            		Console.WriteLine("\nExercise 5");
            		//Query syntax
		        Console.WriteLine("Query syntax");
            		var freq = from p in e5
                       		   group p by p into gy
                       		   select new { Count = gy.Count(), Value = gy.Key };
            		foreach (var i in freq)
            		{
                		Console.WriteLine("{0} occurs {1} times",i.Value,i.Count);
            		}
            		//Method syntax
            		Console.WriteLine("Method syntax");
            		var freq2 = e5.GroupBy(p => p).Select(g=> new {Value=g.Key,Count=g.Count() });
            		freq2.ToList().ForEach(g => Console.WriteLine("{0} ocurs {1} times", g.Value, g.Count));
		}


	}


}
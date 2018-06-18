using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			Console.WriteLine("\nExercise 3");
            		int[] e3 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
            		//Query syntax
            		Console.WriteLine("Query Method");
            		IEnumerable<double> biggerThanZero = from btz in e3
                                 		             where btz > 0
   								 select Math.Pow(btz,2);
            		foreach (int i in biggerThanZero)
            		{
                		Console.WriteLine(i);
            		}
            		//Method syntax
            		Console.WriteLine("Method syntax");
            		IEnumerable<int> biggerThanZero2 =e3.Where(e => e > 0);
            		biggerThanZero2.ToList().ForEach(p => Console.WriteLine(Math.Pow(p,2)));
		}


	}


}
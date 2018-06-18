using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			Console.WriteLine("\nExercise 4");
            		int[] e4 = new[] { 3, 9, 2, 8, 6, 5 };
            		//Query syntax
            		Console.WriteLine("Query syntax");
            		IEnumerable < int > squareBiggerThan20= from square in e4
                        		            		where Math.Pow(square, 2) > 20
                                    				select square;
            		foreach (int i in squareBiggerThan20)
            		{
                		Console.WriteLine(i);
            		}
            		//Method syntax
            		Console.WriteLine("Method syntax");
            		IEnumerable<int> squareBiggerThan20Method = e4.Where(p => Math.Pow(p, 2) > 20);
            		squareBiggerThan20Method.ToList().ForEach(p => Console.WriteLine(p));
		}


	}


}
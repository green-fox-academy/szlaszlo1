using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			Console.WriteLine("\nExercise 2");
            		int[] e2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
	    		//Query syntax
            		Console.WriteLine("Qery syntax");
           		var averageOddNumber = from odd in e2
                           		       where odd % 2 != 0
                            		       select odd;
		        Console.WriteLine(averageOddNumber.Average());

		        //Method syntax
            		Console.WriteLine("Method syntax");
            		double averageOddNumber2 = e2.Where(odd => odd % 2 != 0).Average();
            		Console.WriteLine(averageOddNumber2);
		}


	}


}
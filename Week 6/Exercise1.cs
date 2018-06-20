using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			//Exercise 1
	            	Console.WriteLine("Exercise 1");
			int[] n = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };
		        // Query syntax
            		Console.WriteLine("Query syntax");
			var evenNumbers = from i in n
 					where i % 2 == 0
                      			select i ;
           		foreach (int i in evenNumbers)
            		{
                	Console.WriteLine(i);
	  		}
            		//Method syntax
           		 Console.WriteLine("Method syntax");
            		var evenNumbers2 = n.Where(x => x % 2 == 0);
            		evenNumbers2.ToList().ForEach(p => Console.WriteLine(p));

			}


	}


}
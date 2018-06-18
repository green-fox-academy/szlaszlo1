using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			//Exercise 7
 		        string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
            		//Query syntax
            		Console.WriteLine("Query syntax");
            		IEnumerable<string> city = from c in cities
                      		                   where c.StartsWith("A") && c.EndsWith("I")
                                  		   select c;
            		foreach (string item in city)
            		{
               		    Console.WriteLine(item);
            		}
            		//Method syntax
            		IEnumerable<string> city2 = cities.Where(cit => cit.StartsWith("A") && cit.EndsWith("I"));
            		city2.ToList().ForEach(g => Console.WriteLine(g));
		}


	}


}
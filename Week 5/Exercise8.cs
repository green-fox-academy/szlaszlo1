using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			//Exercise 8
            		//Write a LINQ Expression to find the uppercase characters in a string!
            		Console.WriteLine("\nExercise 8");
            		Console.WriteLine("Write UPPERCASE and lowercase characters");
            		string s2 = Console.ReadLine();
            		while (s2=="")
            		{
                		Console.WriteLine("Write UPPERCASE and lowercase characters");
                		s2 = Console.ReadLine();
            		}
            		//Query syntax
            		Console.WriteLine("Query syntax");
            		IEnumerable<char> uppercase = from ucase in s2
                        		              where ucase.ToString() == ucase.ToString().ToUpper()
                                     		      select ucase;
            		foreach (char item in uppercase)
            		{
               		 Console.WriteLine(item);
            		}
            		//Method syntax
            		Console.WriteLine("Method syntax");
            		IEnumerable<char> uppercase2 = s2.Where(s => s.ToString() == s.ToString().ToUpper());
            		uppercase2.ToList().ForEach(u => Console.WriteLine(u));
            		Console.ReadKey();
		}


	}


}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			 //Exercise 9
            //Write a LINQ Expression to convert a char array to a string!
            char[] karakterek = new char[] { 'a', '?', 'L', 'p', 'n', 'F', '4', 'u' };
            //Query syntax
            Console.WriteLine("Query syntax");
            

            //Console.WriteLine(charToString);
            //Method syntax
            Console.WriteLine("Method syntax");
            string charToString2 = String.Concat(karakterek.Select(p => p.ToString()).ToList());
            Console.WriteLine(charToString2);
            Console.ReadKey();
		}


	}


}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linqexercise
{
	public class Program
	{
		public static void Main(string[] args)
        	{
			//Exercise 6
           		Console.WriteLine("\n Exercise 6");
			Console.WriteLine("Write some text");
            		//Query syntax
            		Console.WriteLine("Query syntax");
            		string s1=Console.ReadLine();
            		while (s1=="")
            		{
                		Console.WriteLine("Write some text");
                		s1 = Console.ReadLine();
            		}
            		var characterFrequency = from i in s1
                                    		 group i by i into g
                                     		 select new { Letter = g.Key, Freq = g.Count() };

			foreach (var item in characterFrequency)
			{
        			Console.WriteLine("Letter \"{0}\" occurs {1} times",item.Letter,item.Freq);
           		}

            		//Method syntax
           		var characterFrequency2 = s1.GroupBy(s => s).Select(s => new { Character = s.Key, Frequency = s.Count() });
           		characterFrequency2.ToList().ForEach(p => Console.WriteLine("Character \"{0}\" occurs {1} times",p.Character,p.Frequency));
		}


	}


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculation c = new Calculation();
            string i=c.HighHand("Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH");
            Console.Write(i);
            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTDD
{
    public class Calculation
    {
        public int GetCardWithoutSymbol(string s)
        {

            return GetValue(s[0].ToString());
        }
        public int GetValue(string s)
        {
            int x;
            try
            {
                x = Convert.ToInt32(s);
                return x;
            }
            catch (Exception)
            {
                switch (s)
                {
                    case "T":
                        return 10;
                    case "J":
                        return 11;
                    case "Q":
                        return 12;
                    case "K":
                        return 13;
                    case "A":
                        return 14;
                    default:
                        break;
                }
            }
            return 0;
        }
    }
}

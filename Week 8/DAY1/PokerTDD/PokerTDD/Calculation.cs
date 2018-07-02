using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTDD
{
    public class Calculation
    {
        public bool CheckLength(string a)
        {
            string[] hands = a.Split(' ');
            return hands.Length == 12;
        }

        public string HighHand(string a)
        {
            string[] tomb = a.Split(' ');
            string[,] black =new string[5,2];
            string[,] white = new string[5,2];
            for (int i = 0; i < 5; i++)
            {
                black[i,0] = tomb[i + 1].Substring(0,1);
                black[i, 1] = tomb[i + 1].Substring(1);
                white[i, 0] = tomb[i + 7].Substring(0, 1);
                white[i, 1] = tomb[i + 7].Substring(1);
            }
            ConvertToint(black);
            ConvertToint(white);
            for (int i = 0; i < 5; i++)
            {
                for (int k = i; k > 0; k--)
                {
                    if (Convert.ToInt32(black[k,0])>Convert.ToInt32(black[k-1,0]))
                    {
                        string temp = black[k, 0];
                        black[k, 0] = black[k - 1, 0];
                        black[k-1, 0] = temp;
                    }

                    if (Convert.ToInt32(white[k, 0]) > Convert.ToInt32(white[k - 1, 0]))
                    {
                        string temp = white[k, 0];
                        white[k, 0] = white[k - 1, 0];
                        white[k - 1, 0] = temp;
                    }
                }
                
                
            }
            bool gotWinner = false;
            int h = 0;
            string verdict="Tie";
            while (!gotWinner && h<5)
            {
                if (Convert.ToInt32(black[h,0])> Convert.ToInt32(white[h, 0]))
                {
                    gotWinner = true;
                    verdict = "Black wins";
                }
                else if (Convert.ToInt32(black[h, 0]) < Convert.ToInt32(white[h, 0]))
                {
                    gotWinner = true;
                    verdict = "White wins";
                }
                
                h++;
            }
            return verdict;
        }

        public void ConvertToint(string[,] s)
        {
            for (int i = 0; i < s.GetLength(0); i++)
            {
                switch (s[i,0])
                {
                    case "T":
                        s[i, 0] = "10";
                        break;
                    case "J":
                        s[i, 0] = "11";
                        break;
                    case "Q":
                        s[i, 0] = "12";
                        break;
                    case "K":
                        s[i, 0] = "13";
                        break;
                    case "A":
                        s[i, 0] = "14";
                        break;
                    default:
                        break;
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anagramm.Services
{
    public class CheckForAnagramm : IAnagramChecker
    {
        bool IAnagramChecker.CheckForAnagramm(string anagramm)
        {
            bool verdict = true ;
            for (int i = 0; i < anagramm.Length/2; i++)
            {
                if (anagramm[i] != anagramm[anagramm.Length - 1 - i])
                    verdict = false;
            }
            return verdict;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class UntilModelMethods
    {
        public static int CalculateFactor(int? countFactorUntil)
        {
            int result=1;
            if (countFactorUntil == null)
            {
                result = 0;
            }
            else
            {
                for (int i =2; i <= countFactorUntil.Value; i++)
                {
                    result *= i;
                }
            }
            return result;
        }

        public static int CalculateSum(int? counSumtUntil)
        {
            int result = 0;
            if (counSumtUntil==null)
            {
                result = -1;
            }
            else
            {
                for (int i = 1; i <= counSumtUntil.Value; i++)
                {
                    result += i;
                }
            }
            return result;
        }
    }
}

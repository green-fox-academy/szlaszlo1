using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Until
    {
        public int? until { get; set; }

        public int CalculateFactor()
        {
            if (this.until == null)
            {
                return -1;

            }
            else
            {
                int result = 1;
                for (int i = 2; i < until.Value; i++)
                {
                    result *= i;
                }
                return result;
            }

        }
    }
}

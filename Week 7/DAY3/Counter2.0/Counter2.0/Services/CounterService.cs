using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counter2._0.Services
{
    public class CounterService : ICounter
    {
        private int countClicks = 0;
        public int GetNumber()
        {
            return countClicks;
        }

        public void Increase()
        {
            countClicks++;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counter2._0.Services
{
    public interface ICounter
    {
        int GetNumber();
        void Increase();
    }
}

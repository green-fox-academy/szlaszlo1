using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetSomeone.Services
{
    public class GreetName : IGreetName
    {
        private string yourName;
        public string GetName()
        {
            return yourName;
        }
    }
}

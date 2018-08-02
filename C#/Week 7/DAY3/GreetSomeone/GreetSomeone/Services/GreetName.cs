using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetSomeone.Services
{
    public class GreetName : IGreetName
    {
        public string yourName="Vmi";
        public string GetName()
        {
            return yourName;
        }
        public void SetName(string s)
        {
            yourName = s;
        }
    }
}

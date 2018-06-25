using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPD01.Models
{
    public class Greeting
    {
        private static long _id = 0;
        public long Id { get; set; }
        public string Content { get; set; }
        //public Greeting()
        //{

        //}
        public Greeting(string name="Anonimous")
        {
            Id = _id;
            _id++;
            Content = "Hello "+name+"!";
        }
    }
}

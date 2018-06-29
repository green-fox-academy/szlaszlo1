using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Models
{
    public class Fox
    {
        public string Name { get; set; }
        public List<string> Tricks { get; set; }
        public Nutrition Food { get; set; }
        public Nutrition Drink { get; set; }
        public Stack<string> HistoryElement { get; set; }
    }
}

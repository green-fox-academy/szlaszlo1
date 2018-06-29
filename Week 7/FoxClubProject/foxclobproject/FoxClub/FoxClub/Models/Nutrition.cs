using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Models
{
    public class Nutrition
    {
        public string Name { get; set; }
        public bool IsFood { get; set; }
        public int Portion { get; set; }
        public DateTime AddedTime { get; set; }
    }
}

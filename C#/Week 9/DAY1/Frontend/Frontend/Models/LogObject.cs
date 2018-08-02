using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class LogObject
    {
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        public string endpoint { get; set; }
        public string data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;

namespace ToDo.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Finished { get; set; }
        public bool Urgent { get; set; }
    }
}

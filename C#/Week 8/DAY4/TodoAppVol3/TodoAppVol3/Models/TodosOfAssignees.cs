using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppVol3.Models
{
    public class TodosOfAssignees
    {
        public List<Assignee> Asignees { get; set; }
        public List<Todo> Todos { get; set; }
        public bool[] Show { get; set; }
    }
}

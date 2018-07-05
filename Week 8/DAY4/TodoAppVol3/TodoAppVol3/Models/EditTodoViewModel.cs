using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppVol3.Models
{
    public class EditTodoViewModel
    {
        public Todo Todo { get; set; }
        public List<Assignee> Assignees { get; set; }
    }
}

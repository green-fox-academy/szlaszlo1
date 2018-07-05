using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppVol3.Models;

namespace TodoAppVol3.Services
{
    public interface ITodoApp
    {
        List<Todo> ListAllTodo();
        List<Assignee> ListAllAssignee();
        void AddNew(Todo t);
        void AddNew(Assignee a);
        void Update(Todo t);
        void Update(Assignee a);
    }
}

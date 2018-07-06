using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Repositories;
using TodoAppVol3.Models;

namespace TodoAppVol3.Repositories
{
    public class AssigneeRepository : ITodoRepository<Assignee>
    {
        TodoContext todoContext;
        public AssigneeRepository(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }
        public void AddNew(Assignee assignee)
        {
            todoContext.Assignees.Add(assignee);
            todoContext.SaveChanges();
        }

        public void Delete(long id)
        {
            todoContext.Assignees.Remove(todoContext.Assignees.FirstOrDefault(x => x.Id == id));
            todoContext.SaveChanges();
        }

        public Assignee GetElement(long id)
        {
            return todoContext.Assignees.FirstOrDefault(x => x.Id == id);
        }

        public List<Assignee> LisrSearch(string searchedString)
        {
            return todoContext.Assignees.Where(x => x.Name.ToLower().Contains(searchedString.ToLower())).ToList();
        }

        public List<Assignee> ListAll()
        {
            return todoContext.Assignees.Include(a=>a.Todos).ToList();
        }

        public void Update(Assignee t)
        {
            todoContext.Assignees.Update(t);
            todoContext.SaveChanges();
        }
        public void UpdateBoth(Assignee t)
        {
            todoContext.Assignees.Update(t);
            todoContext.SaveChanges();
        }
    }
}

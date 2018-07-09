using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TodoAppVol3.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository<Todo>
    {
        private TodoContext todoContext;
        public TodoRepository(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }


        public List<Todo> ListAll()
        {
            return todoContext.Todos.Include(x => x.Assignee).ToList();

            //return todoContext.Todos.ToList();
        }
        public void AddNew(Todo todo)
        {
            todoContext.Todos.Add(todo);
            todoContext.SaveChanges();
        }

        public void Delete(long id)
        {
            todoContext.Todos.Remove(todoContext.Todos.FirstOrDefault(x => x.Id == id));
            todoContext.SaveChanges();
        }

        public void Update(Todo t)
        {
            todoContext.Todos.Update(t);
            todoContext.SaveChanges();
            
        }

        public Todo GetElement(long id)
        {
            return todoContext.Todos.FirstOrDefault(x => x.Id == id);
        }

        public List<Todo> LisrSearch(string searchedString)
        {
           
            return todoContext.Todos.Where(x => x.Title.ToLower().Contains(searchedString.ToLower())).ToList();
        }
        public void UpdateBoth(Todo t)
        {
            /*if (todoContext.Assignees.FirstOrDefault(x => x.Id == t.Assignee.Id).Todos == null)
            {
                todoContext.Assignees.FirstOrDefault(x => x.Id == t.Assignee.Id).Todos = new Collection<Todo>();
            }
            todoContext.Assignees.FirstOrDefault(x => x.Id == t.Assignee.Id).Todos.Add(t);
            todoContext.Update(todoContext.Assignees.FirstOrDefault(x => x.Id == t.Assignee.Id));
            //todoContext.SaveChanges();*/
            todoContext.Todos.FirstOrDefault(x => x.Id == t.Id).Assignee = todoContext.Assignees.FirstOrDefault(y => y.Id == t.Assignee.Id);
            todoContext.Todos.FirstOrDefault(x => x.Id == t.Id).Title = t.Title;
            todoContext.Todos.FirstOrDefault(x => x.Id == t.Id).IsUrgent = t.IsUrgent;
            todoContext.Todos.FirstOrDefault(x => x.Id == t.Id).IsDone = t.IsDone;
            //todoContext.Todos.Update(t);

            todoContext.SaveChanges();



        }
        
    }
}

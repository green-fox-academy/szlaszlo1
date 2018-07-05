using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppVol3.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private TodoContext todoContext;
        public TodoRepository(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }


        public List<Todo> ListAll()
        {
            return todoContext.Todos.ToList();
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

        public Todo Edit(long id)
        {
            return todoContext.Todos.FirstOrDefault(x => x.Id == id);
        }

        public List<Todo> LisrSearch(string searchedString)
        {
            return todoContext.Todos.Where(x => x.Title.ToLower().Contains(searchedString.ToLower())).ToList();
        }
    }
}

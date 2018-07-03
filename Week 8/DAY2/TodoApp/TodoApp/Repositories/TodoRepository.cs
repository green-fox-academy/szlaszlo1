﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository:ITodoRepository
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
    }
}

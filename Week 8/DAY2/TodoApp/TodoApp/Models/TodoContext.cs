using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TodoContext:DbContext
    {
        List<Todo> todoList = new List<Todo>();
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
    }
}

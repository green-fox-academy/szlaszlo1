using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppVol3.Models
{
    public class TodoContext:DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Assignee> Assignees { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
    }
}

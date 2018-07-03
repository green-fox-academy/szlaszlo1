using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository
    {
        List<Todo> ListAll();
        void AddNew(Todo todo);
        void Delete(long id);
    }
}

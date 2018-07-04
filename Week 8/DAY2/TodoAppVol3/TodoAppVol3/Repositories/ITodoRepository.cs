using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppVol3.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository
    {
        List<Todo> ListAll();
        void AddNew(Todo todo);
        void Delete(long id);
        void Update(Todo t);
        Todo Edit(long id);
    }
}

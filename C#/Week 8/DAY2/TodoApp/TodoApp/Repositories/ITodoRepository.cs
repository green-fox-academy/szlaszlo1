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
        List<Todos> ListAll();
        void AddNew(Todos todo);
        void Delete(long id);
        void Update(Todos t);
        Todos Edit(long id);
    }
}

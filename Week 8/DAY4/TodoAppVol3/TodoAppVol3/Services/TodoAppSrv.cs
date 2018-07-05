using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Repositories;
using TodoAppVol3.Models;

namespace TodoAppVol3.Services
{
    public class TodoAppSrv:ITodoApp
    {
        ITodoRepository<Todo> todorep;
        ITodoRepository<Assignee> assigneerep;
        public TodoAppSrv()
        {

        }
    }
}

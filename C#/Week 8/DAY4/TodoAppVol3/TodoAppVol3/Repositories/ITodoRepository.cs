using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppVol3.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository<Type>
    {
        List<Type> ListAll();
        void AddNew(Type todo);
        void Delete(long id);
        void Update(Type t);
        Type GetElement(long id);
        List<Type> LisrSearch(string searchedString);
    }
}

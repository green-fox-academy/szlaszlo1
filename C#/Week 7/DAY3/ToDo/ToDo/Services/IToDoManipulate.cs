using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoManipulate
    {
        void AddToDo(Models.ToDo td);
        void CheckToDo(int id);
        void DeleteToDo(int id);
        void UrgentToDo(int id);
        List<Models.ToDo> GetToDos();
        void SaveAll();
        void LoadAll();
    }
}

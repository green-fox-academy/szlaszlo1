using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Services
{
    public class ToDoManipulate : IToDoManipulate
    {
        private int _id = 0;
        List<Models.ToDo> todo = new List<Models.ToDo>();
        public void AddToDo(Models.ToDo td)
        {
            td.CreatedAt = DateTime.Now;
            SetID(td);
            todo.Add(td);
        }
        private void SetID(Models.ToDo td)
        {
            td.ID = _id++;

        }
        public void CheckToDo(int id)
        {
            todo.Where(x => x.ID == id).ToList().ForEach(y => y.Finished = true);
        }

        public void DeleteToDo(int id)
        {
            todo.FindAll(x => x.ID == id).ForEach(y => todo.Remove(y));
        }

        public List<Models.ToDo> GetToDos()
        {
            return todo;
        }

        public void UrgentToDo(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Repositories;
using TodoAppVol3.Models;
using TodoAppVol3.Repositories;

namespace TodoAppVol3.Services
{
    public class TodoAppSrv:ITodoApp
    {
        TodoRepository todorep;
        AssigneeRepository assigneerep;
        public TodoAppSrv(TodoRepository todorep, AssigneeRepository assigneerep)
        {
            this.todorep = todorep;
            this.assigneerep = assigneerep;
        }
        public List<Assignee> ListAllAssignee()
        {
            return assigneerep.ListAll();
        }

        public List<Todo> ListAllTodo()
        {
            return todorep.ListAll();
        }

        public void AddNew(Todo t)
        {
            t.CreatedAt = DateTime.Now;
            todorep.AddNew(t);
        }

        public void AddNew(Assignee a)
        {
            assigneerep.AddNew(a);
        }

        public void Update(Todo t)
        {
            todorep.Update(t);
        }

        public void Update(Assignee a)
        {
            assigneerep.Update(a);
        }

        public Todo GetTodo(long id)
        {
            return todorep.GetElement(id);
        }

        public Assignee GetAssignee(long id)
        {
            return assigneerep.GetElement(id);
        }

        public void DeleteTodo(long id)
        {
            todorep.Delete(id);
        }

        public void DeleteAssignee(long[] id)
        {
            foreach (long i in id)
            {
                assigneerep.Delete(i);
            }
        }

        public List<Todo> GetFilteredTodo(string searchedString)
        {
            return todorep.LisrSearch(searchedString);
        }
        public List<Assignee> GetFilteredAssignee(string searchedString)
        {
            return assigneerep.LisrSearch(searchedString);
        }

        public EditTodoViewModel GetViewModel(long id)
        {
            return new EditTodoViewModel { Todo = todorep.GetElement(id), Assignees = assigneerep.ListAll() };
        }

        public void SetConnection(Todo t)
        {

            todorep.UpdateBoth(t);
            
        }

        public TodosOfAssignees GetTodoOfAssigneesViewModel()
        {
            TodosOfAssignees toa = new TodosOfAssignees { Todos = todorep.ListAll(), Asignees = assigneerep.ListAll() };
            toa.Show = new bool[toa.Asignees.Count];
            for (int i = 0; i < toa.Asignees.Count; i++)
            {
                toa.Show[i] = false;
            }
            return toa;
        }

        public TodosOfAssignees GetTodoOfAssigneesViewModel(int index)
        {
            TodosOfAssignees toa = new TodosOfAssignees { Todos = todorep.ListAll(), Asignees = assigneerep.ListAll() };
            toa.Show = new bool[toa.Asignees.Count];
            for (int i = 0; i < toa.Asignees.Count; i++)
            {
                if (toa.Asignees.ElementAt(i).Id==index)
                {
                    toa.Show[i] = true;
                }
                else
                {
                    toa.Show[i] = false;
                }
                
            }
            return toa;
        }
    }
}

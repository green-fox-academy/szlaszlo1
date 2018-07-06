using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAppVol3.Models;

namespace TodoAppVol3.Services
{
    public interface ITodoApp
    {
        List<Todo> ListAllTodo();
        List<Assignee> ListAllAssignee();
        void AddNew(Todo t);
        void AddNew(Assignee a);
        void Update(Todo t);
        void Update(Assignee a);
        Todo GetTodo(long id);
        Assignee GetAssignee(long id);
        void DeleteTodo(long id);
        void DeleteAssignee(long id);
        List<Todo> GetFilteredTodo(string searchedString);
        List<Assignee> GetFilteredAssignee(string searchedString);
        EditTodoViewModel GetViewModel(long id);
        TodosOfAssignees GetTodoOfAssigneesViewModel();
        TodosOfAssignees GetTodoOfAssigneesViewModel(int index);
        void SetConnection(Todo t);
    }
}

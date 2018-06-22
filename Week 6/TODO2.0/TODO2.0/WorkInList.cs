using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TODO;

namespace TODO2._0
{
    class WorkInList:Persistance
    {
        public void Save(TODO.TODO t)
        {
            Program.todos.Add(t);
        }
        public void SaveAll(List<TODO.TODO> t)
        {
            t.ForEach(x => Program.todos.Add(x));
        }
        public void CheckCompleted(int id)
        {
            Program.todos.FindAll(x => x.Id == id).ForEach(y => { y.CompletedAt = DateTime.Now; Console.WriteLine(y.Text + " finished at: " + y.CompletedAt); });
            
        }

        public void Load(int id)
        {
            Program.todos.FindAll(x => x.Id == id && x.CompletedAt != null).ForEach(y => Console.WriteLine($"{y.Id} {y.Text} {(y.CompletedAt - y.CreatedAt).Days}"));
            Program.todos.FindAll(x => x.Id == id && x.CompletedAt == null).ForEach(y => Console.WriteLine($"{y.Id} {y.Text}"));
        }

        public void Load(string str)
        {
            Program.todos.FindAll(x => x.Text.IndexOf(str)!=-1).ForEach(y => Console.WriteLine($"{y.Id} {y.Text}"));
        }

        public void LoadAll()
        {
            Program.todos.ForEach(y => Console.WriteLine($"{y.Id} {y.Text} {y.CreatedAt} {y.CompletedAt}"));
        }

        public void RemoveElement(int id)
        {
            Program.todos.Remove(Program.todos.ElementAt(id));
        }   

        public void UpdateElement(int id, string text)
        {
            Program.todos.FindAll(x => x.Id == id).ForEach(y => { y.Text=text; Console.WriteLine(y.Id + " updated to: " + y.Text); });
        }

       
    }
}

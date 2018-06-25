using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using TODO;

namespace TODO2._0
{
   public class WorkInList:Persistance
    {
        public void Save(TODO.TODO t)
        {
            Program.todos.Add(t);
            Console.WriteLine("Item added to the list");
            //LoadAll();
        }
        public void SaveAll(List<TODO.TODO> t)
        {
            t.ForEach(x => Program.todos.Add(x));
            Console.WriteLine("Items added to the list");
            //LoadAll();
        }
        public void CheckCompleted(int id)
        {
            if(Program.todos.FindAll(x => x.Id == id).ToArray().Count() > 0)
            {
                Program.todos.FindAll(x => x.Id == id).ForEach(y => { y.CompletedAt = DateTime.Now; Console.WriteLine(y.Text + " finished at: " + y.CompletedAt); });
            }
            else
            {
                throw new Exception($"Check failed: no task with specified id {id} exist");
            }
        }

        public void Load(int id)
        {
            if(Program.todos.FindAll(x => x.Id == id).ToArray().Count() > 0)
            {
                //Program.todos.FindAll(x => x.Id == id && x.CompletedAt != null).ForEach(y => Console.WriteLine($"{y.Id} {y.Text} {(y.CompletedAt - y.CreatedAt).Days}"));
                //Program.todos.FindAll(x => x.Id == id && x.CompletedAt == null).ForEach(y => Console.WriteLine($"{y.Id} {y.Text}"));
                Program.todos.FindAll(x => x.Id == id).ForEach(y => { if (y.CompletedAt > y.CreatedAt) Console.WriteLine($"{y.Id} {y.Text} {(y.CompletedAt - y.CreatedAt).Days}");else Console.WriteLine($"{y.Id} {y.Text}");});
            }
            else
            {
                throw new Exception($"No task with specified id: {id}");
            }
            
        }

        public void Load(string str)
        {
            if(Program.todos.FindAll(x => x.Text.IndexOf(str) != -1).ToArray().Count()>0)
            {
                //Program.todos.FindAll(x => x.Text.IndexOf(str) != -1).ForEach(y => Console.WriteLine($"{y.Id} {y.Text}"));
                Program.todos.FindAll(x => x.Text.IndexOf(str) != -1).ForEach(y => { if (y.CompletedAt > y.CreatedAt) Console.WriteLine($"{y.Id} {y.Text} {(y.CompletedAt - y.CreatedAt).Days}"); else Console.WriteLine($"{y.Id} {y.Text}"); });
            }
            else
            {
                throw new Exception("No task with specified string");
            }
            
        }

        public void LoadAll()
        {
            //Program.todos.ForEach(y => Console.WriteLine($"{y.Id} {y.Text} {y.CreatedAt} {y.CompletedAt}"));
            Program.todos.ForEach(y => { if (y.CompletedAt > y.CreatedAt) Console.WriteLine($"{y.Id} {y.Text} {(y.CompletedAt - y.CreatedAt).Days}"); else Console.WriteLine($"{y.Id} {y.Text}"); });
        }

        public void RemoveElement(int id)
        {
                
                if (Program.todos.FindAll(x => x.Id == id).ToArray().Count() > 0)
                {
                    Program.todos.FindAll(x => x.Id == id).ForEach(x => Program.todos.Remove(x));
                    Console.WriteLine($"Element id:{id} removed");
                }
                else
                {
                    throw new Exception("Remove failed: No task with specified id exist");
                }
        }   

        public void UpdateElement(int id, string text)
        {
           
                Program.todos.FindAll(x => x.Id == id).ForEach(y => { y.Text = text; Console.WriteLine(y.Id + " updated to: " + y.Text); });
                if (Program.todos.FindAll(x => x.Id == id).ToArray().Count()>0)
                {
                    Console.WriteLine($"Task {id} updated to: {text}");
                }
                else
                {
                    Console.WriteLine($"No task with specified id: {id}");
                }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TODO2._0
{
    interface Persistance
    {
        void Save(TODO.TODO t);
        void SaveAll(List<TODO.TODO> t);
        void Load(int id);
        void Load(string str);
        void LoadAll();
        void RemoveElement(int id);
        void CheckCompleted(int id);
        void UpdateElement(int id, string text);
    }
}

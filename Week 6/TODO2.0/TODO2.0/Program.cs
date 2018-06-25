using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TODO
{
    
    class Program
    {
        public static List<TODO> todos;
        public static SQLiteConnection sqliteConnection;
        static void Main(string[] args)
        {

            if(args.Length!=0)
            {
                string[] commands = { "-a", "-l", "-r", "-c", "-u" };
                if (commands.Any(elem => elem.Equals(args[0])))
                {
                    string dbName = "MyDatabase.sqlite";
                    
                    if (File.Exists(dbName))
                    {
                        //Console.WriteLine("Database already exist, connect to database...");
                        sqliteConnection = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                        sqliteConnection.Open();
                        //Console.WriteLine("Connected to database");
                    }
                    else
                    {
                        //Console.WriteLine("Create database...");
                        SQLiteConnection.CreateFile(dbName);
                        //Console.WriteLine("Database created");
                        //Console.WriteLine("Connect to database");
                        sqliteConnection = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                        sqliteConnection.Open();
                        //Console.WriteLine("Connected to database");
                    }
                    string createTable = @"CREATE TABLE IF NOT EXISTS Todos(
                                           id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                           text NVARCHAR(2048) NOT NULL,
                                           createdAt DATETIME NOT NULL,
                                           completedAt DATETIME)";
                    SQLiteCommand command = new SQLiteCommand(createTable, sqliteConnection);
                    command.ExecuteNonQuery();

                    switch (args[0])
                    {
                        case "-a":
                            if (args.Length == 1)
                            {
                                Console.WriteLine("Unable to add: no task provided");
                            }
                            else if (args.Length==2)
                            {
                                TODO t = new TODO(args[1]);
                                SaveToDB.Save(t);
                            }
                            else
                            {
                                List<TODO> t = new List<TODO>();
                                for (int i = 1; i < args.Length; i++)
                                {
                                    t.Add(new TODO(args[i].ToString()));
                                }
                                SaveToDB.SaveAll(t);
                            }
                            break;
                        case "-l":
                            if (args.Length == 1)
                            {
                                SaveToDB.LoadAll();
                            }
                            else
                            {
                                try
                                {
                                    int x = Convert.ToInt32(args[1]);
                                    try
                                    {
                                        SaveToDB.Load(x);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);   
                                    }
                                }
                                catch
                                {
                                    string loadText = "";
                                    for (int i = 1; i < args.Length; i++)
                                    {
                                        if (i != args.Length - 1)
                                        {
                                            loadText += args[i].ToString() + " ";
                                        }
                                        else
                                        {
                                            loadText += args[i].ToString();
                                        }
                                    }
                                    try
                                    {
                                        SaveToDB.Load(loadText);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                            }
                            break;
                        case "-r":
                            if (args.Length == 1)
                            {
                                Console.WriteLine("Unable to remove: no index provided");
                            }
                            else
                            {
                                try
                                {
                                    int x = Convert.ToInt32(args[1]);
                                    try
                                    {
                                        SaveToDB.RemoveElement(x);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    throw new Exception("Unable to remove: index is not a number");
                                }
                            }
                            break;
                        case "-c":
                            if (args.Length==1)
                            {
                                Console.WriteLine("Unable to check: no index provided");
                            }
                            else if(args.Length==2)
                            {
                                try
                                {
                                    int x = Convert.ToInt32(args[1]);
                                    try
                                    {
                                        SaveToDB.CheckCompleted(x);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    throw new Exception("Unable to remove: index is not a number");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Too much arguments");
                            }
                            break;
                        case "-u":
                            if (args.Length == 1)
                            {
                                Console.WriteLine("Unable to update: no id defined");
                            }
                            else if (args.Length == 3)
                            {
                                try
                                {
                                    int x=Convert.ToInt32(args[1]);
                                    try
                                    {
                                        SaveToDB.UpdateElement(x, args[2]);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Too much arguments");
                            }
                            break;
                        default:
                            break;
                    }


                    sqliteConnection.Close();
                }
                else
                {
                    Console.WriteLine(args[0] + " nem egy létező paraméter");
                }
            }
            else
            {
                todos = new List<TODO>();
                bool tovabb = true;

                while (tovabb)
                {
                    string command = Console.ReadLine();
                    string arg="";
                    if(command.Length>=2)
                    arg = command.Substring(0, 2);
                    string parameter = "";
                    string[] parameters=new string[0];
                    if (command.ToLower()!="exit")
                    {
                        string restArg = "";
                        if (command.Length>=4)
                        {
                            restArg = command.Substring(3);
                        }

                        List<string> tempParamsList = new List<string>();
                        while (restArg != "")
                        {
                            
                            if (restArg.IndexOf('"') == -1)
                            {
                                if (restArg.IndexOf(' ') == -1)
                                {
                                    parameter = restArg;
                                    tempParamsList.Add(parameter);
                                    parameters = new string[0];
                                    restArg = "";
                                }
                                else
                                {
                                    parameters = restArg.Split(' ');
                                    foreach (string param in parameters)
                                    {
                                        tempParamsList.Add(param);
                                    }
                                    restArg = "";
                                }

                            }
                            else
                            {
                                if (restArg.Count(x => x == '"') % 2 == 0)
                                {
                                    if (restArg.IndexOf(' ') == -1)
                                    {
                                            parameter = restArg.Substring(1, restArg.Length - 2);
                                            tempParamsList.Add(parameter);
                                            restArg = "";
                                    }
                                    else
                                    {

                                        

                                        if (restArg.IndexOf('"') != 0 && restArg.ElementAt(restArg.IndexOf('"') - 1) != ' ')
                                            restArg = restArg.Substring(0, restArg.IndexOf('"')) + " " + restArg.Substring(restArg.IndexOf('"'), restArg.Length - restArg.IndexOf('"'));
                                        string tempStr;
                                        string tempSub = "";
                                        if (restArg.IndexOf('"') < restArg.IndexOf(" "))
                                        {
                                            tempSub = restArg.Substring(1);
                                            tempStr = tempSub.Substring(0, tempSub.IndexOf('"'));
                                            tempParamsList.Add(tempStr);
                                            if (tempSub.IndexOf('"') + 1 <= tempSub.Length - 1)
                                            {
                                                if (tempSub.ElementAt(tempSub.IndexOf('"') + 1) != ' ')
                                                {
                                                    tempSub = tempSub.Substring(0, tempSub.IndexOf('"') + 1) + ' ' + tempSub.Substring(tempSub.IndexOf('"'), tempSub.Length - tempSub.IndexOf('"'));
                                                }
                                                restArg = tempSub.Substring(tempSub.IndexOf('"') + 2, tempSub.Length - tempSub.IndexOf('"') - 2);
                                            }
                                            else
                                            {
                                                restArg = "";
                                            }
                                        }
                                        else if (restArg.IndexOf(" ") == -1)
                                        {
                                            if (tempSub.ElementAt(tempSub.IndexOf('"') + 1) != ' ')
                                            {
                                                tempSub = tempSub.Substring(0, tempSub.IndexOf('"') + 1) + ' ' + tempSub.Substring(tempSub.IndexOf('"'), tempSub.Length - tempSub.IndexOf('"'));
                                            }
                                            restArg = tempSub.Substring(tempSub.IndexOf('"') + 2, tempSub.Length - tempSub.IndexOf('"') - 2);
                                        }
                                        else
                                        {

                                            tempStr = restArg.Substring(0, restArg.IndexOf(' '));
                                            tempParamsList.Add(tempStr);
                                            restArg = restArg.Substring(restArg.IndexOf(' ') + 1);
                                        }
                                    }
                                    
                                    parameter = "";



                                }
                                else
                                {
                                    Console.WriteLine("Not right input format: Invalid number of \"");
                                    restArg = "";
                                }
                            }
                           // Console.WriteLine("itt tartunk");
                        }
                        parameters = tempParamsList.ToArray();
                    }
                    else
                    {
                        tovabb = false;
                    }




                    //string[] parameters;
                    TODO2._0.WorkInList workInList = new TODO2._0.WorkInList();
                    switch (arg)
                    {
                        case "-a":
                            if (parameters.Length == 1)
                            {
                                TODO t = new TODO(parameters[0]);
                                workInList.Save(t);
                            }
                            else if (parameters.Length != 0)
                            {
                                List<TODO> sa = new List<TODO>(); 
                                foreach (string task in parameters)
                                {
                                    TODO t = new TODO(task);
                                    sa.Add(t);
                                }
                                workInList.SaveAll(sa);
                            }
                            else
                            {
                                Console.WriteLine("Can not add items to the list: no task text specified");
                            }
                            break;
                        case "-l":
                            if (parameters.Length==1)
                            {
                                try
                                {
                                    int x = Convert.ToInt32(parameter);
                                    try
                                    {
                                        workInList.Load(x);
                                    }
                                    catch(Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        workInList.Load(parameter);
                                    }
                                    catch(Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                            }
                            else if(parameters.Length==0)
                            {
                                Console.WriteLine("List every task:");
                                workInList.LoadAll();
                            }
                            else
                            {
                                Console.WriteLine("Query failed: too much arguments specified, one or less needed (id- integer, string- text contains, nothing- for all)");
                            }
                            break;
                        case "-c":
                            if (parameters.Length==0)
                            {
                                Console.WriteLine("No id specified");
                            }
                            else if(parameters.Length==1)
                            {
                                try
                                {
                                    int x = Convert.ToInt32(parameter);
                                    try
                                    {
                                        workInList.CheckCompleted(x);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine($"Check failed: id must be an integer");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Check failed: Too much argument specified only one id needed (integer- id of task)");
                            }
                            break;
                        case "-r":
                            if (parameters.Length==0)
                            {
                                Console.WriteLine("Not right input format: You have to use id (integer) to remove an element");
                            }
                            else if(parameters.Length==1)
                            {
                                try
                                {
                                    int x = Convert.ToInt32(parameter);
                                    try
                                    {
                                        workInList.RemoveElement(x);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Not right input format: You have to use id (integer) to remove an element");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Not right input format: You have to use only one parameter (integer as id)");
                            }
                            break;
                        case "-u":
                            if (parameters.Length<=1)
                            {
                                Console.WriteLine("Not enough parameters specified: you need to specify an id (integer) and a text (string) to update an element");
                            }
                            else if(parameters.Length==2)
                            {
                                try
                                {
                                    int x = Convert.ToInt32(parameters[0]);
                                    try
                                    {
                                        workInList.UpdateElement(x, parameters[1]);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Update failed: first parameter must be an integer (id of the task)");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Two much argument specified, you should use \" to update to more than one word");
                            }
                            break;
                        default:
                            Console.WriteLine($"No such a keyword: {arg}");
                            break;
                    }
                }
                Console.WriteLine("Nem adott meg paramétert");
            }

            /* try
             {
                 string[] lines = ReadLines("todo.txt");
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
             }*/
            //Console.ReadKey();
        }
        
        private static string[] ReadLines(string fileName)
        {
            string[] lines = new string[0];
            try
            {
                lines = File.ReadAllLines(fileName);
            }
            catch (IOException e)
            {
                throw new Exception("Nem volt file");
            }
            return lines;
        }
    }
    public class TODO
    {
        private int id;
        private string text;
        private DateTime createdAt;
        private DateTime completedAt;
        private static int id_incr = 1;

        public TODO(string text)
        {
            this.id = TODO.id_incr;
            TODO.id_incr += 1;
            this.text = text;
            this.createdAt = DateTime.Now;
        }

        public int Id
        { get => id; set => id = value; }
        public string Text
        { get => text; set => text = value; }
        public DateTime CreatedAt
        { get => createdAt; set => createdAt = value; }
        public DateTime CompletedAt
        { get => completedAt; set => completedAt = value; }
        public int ComplitionTime()
        {
            TimeSpan requiredDays = completedAt - createdAt;
            int days = requiredDays.Days;
            return days;
        }
        public override string ToString()
        {
            return $"id {id}, text {text}, created at {createdAt}, completed at {completedAt}";
        }
    }
    public class SaveToDB
    {
        public static void Save(TODO t)
        {
            StringBuilder sb = new StringBuilder("INSERT INTO Todos(text,createdAt) VALUES('");
            sb.Append(t.Text);
            sb.Append("','");
            sb.Append(t.CreatedAt);
            sb.Append("')");
            SQLiteCommand cmd=new SQLiteCommand("INSERT INTO Todos(text,createdAt) VALUES(@value,@date)",Program.sqliteConnection);
            cmd.Parameters.AddWithValue("@value",t.Text);
            cmd.Parameters.AddWithValue("@date", t.CreatedAt);
            //SQLiteCommand command = new SQLiteCommand(sb.ToString(), sqlc);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Item: {t.Text} added to your ToDo list");
        }
        public static void SaveAll(List<TODO> todos)
        {
            todos.ForEach(x => Save(x));
        }
        public static void Load(int id)
        {
            bool exist = CheckElement(id);
            if (exist)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Todos WHERE id=@value", Program.sqliteConnection))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            if (r[3].GetType() == typeof(DBNull))
                            {
                                //Console.WriteLine("here");
                                Console.WriteLine($"{r[0]}. {r[1]}");
                            }
                            else
                            {
                                //Console.WriteLine(r[3].GetType().ToString());
                                int days = ComplitionTime(Convert.ToDateTime(r[2]), Convert.ToDateTime(r[3]));
                                Console.WriteLine($"{r[0]}. {r[1]} took {days} days to complete");
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Unable to load: index is out of bound");
            }
            
                
        }
        public static void Load(string text)
        {
            //Console.WriteLine("Jó út");
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Todos WHERE text LIKE @value", Program.sqliteConnection))
            {
                cmd.Parameters.AddWithValue("@value", "%"+text+"%");
                using (SQLiteDataReader r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            if (r[3].GetType() == typeof(DBNull))
                            {
                                //Console.WriteLine("here");
                                Console.WriteLine($"{r[0]}. {r[1]}");
                            }
                            else
                            {
                                //Console.WriteLine(r[3].GetType().ToString());
                                int days = ComplitionTime(Convert.ToDateTime(r[2]), Convert.ToDateTime(r[3]));
                                Console.WriteLine($"{r[0]}. {r[1]} took {days} days to complete");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("No task with this text");
                    }
                }
            }
        }
        public static void LoadAll()
        {
            string listAll = "SELECT * FROM Todos";
            List<TODO> result = new List<TODO>();
            using (SQLiteCommand command = new SQLiteCommand(listAll, Program.sqliteConnection))
            {
                using (SQLiteDataReader r = command.ExecuteReader())
                {
                    if (r.HasRows == false)
                    {
                        Console.WriteLine("No todos for today! :)");
                    }
                    else
                    {
                        while (r.Read())
                        {
                            if (r[3].GetType()==typeof(DBNull))
                            {
                                //Console.WriteLine("here");
                                Console.WriteLine($"{r[0]}. {r[1]}");
                            }
                            else
                            {
                                //Console.WriteLine(r[3].GetType().ToString());
                                    int days = ComplitionTime(Convert.ToDateTime(r[2]), Convert.ToDateTime(r[3]));
                                    Console.WriteLine($"{r[0]}. {r[1]} took {days} day(s) to complete");
                            }
                            
                        }
                    }
                }
            }
        }
        public static bool CheckElement(int id)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Todos WHERE id=@value", Program.sqliteConnection))
            {
                cmd.Parameters.AddWithValue("@value", id);
                using (SQLiteDataReader r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        //Console.WriteLine("true");
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine("false");
                        return false;
                    }
                }
            }
        }
        public static void RemoveElement(int id)
        {
            bool exists = CheckElement(id);
            if (exists)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Todos WHERE id=@value", Program.sqliteConnection))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    SQLiteDataReader r = cmd.ExecuteReader();   
                }
                Console.WriteLine($"Task with id: {id} removed");
            }
            else
            {
                throw new Exception("Unable to remove: index is out of bound");
            }
        }
        public static void CheckCompleted(int id)
        {
            bool exist = CheckElement(id);
            DateTime date = DateTime.Now;
            if (exist)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Todos SET completedAT=@date WHERE id=@value", Program.sqliteConnection))
                {
                    
                    cmd.Parameters.AddWithValue("@value", id);
                    cmd.Parameters.AddWithValue("@date", date);
                    SQLiteDataReader r = cmd.ExecuteReader();
                }
                Console.WriteLine($"Task with id: {id} completed at: {date}");
            }
            else
            {
                throw new Exception("Unable to check: index is out of bound");
            }
        }
        public static void UpdateElement(int id,string text)
        {
            bool exist = CheckElement(id);
            if (exist)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Todos SET text=@text WHERE id=@value", Program.sqliteConnection))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    cmd.Parameters.AddWithValue("@text", text);
                    SQLiteDataReader r = cmd.ExecuteReader();
                }
                Console.WriteLine($"Task with id: {id} updated to: {text}");
            }
            else
            {
                throw new Exception("Unable to update: index is out of bound");
            }
        }
        public static int ComplitionTime(DateTime created, DateTime completed)
        {
            TimeSpan t = new TimeSpan();
            t = completed - created;
            return Convert.ToInt32(t.TotalDays);
        }
    }
}

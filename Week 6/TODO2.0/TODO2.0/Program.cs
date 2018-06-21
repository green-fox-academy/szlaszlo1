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
        private static List<TODO> todos = new List<TODO>();
        static void Main(string[] args)
        {

            if(args.Length!=0)
            {
                string[] commands = { "-a", "-l", "-r", "-c", "-u" };
                if (commands.Any(elem => elem.Equals(args[0])))
                {
                    string dbName = "MyDatabase.sqlite";
                    SQLiteConnection sqliteConnection;
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
                                throw new Exception("Unable to add: no task provided");
                            }
                            else if (args.Length==2)
                            {
                                TODO t = new TODO(args[1]);
                                SaveToDB.Save(t,sqliteConnection);
                            }
                            else
                            {
                                List<TODO> t = new List<TODO>();
                                for (int i = 1; i < args.Length-1; i++)
                                {
                                    t.Add(new TODO(args[i].ToString()));
                                }
                                SaveToDB.SaveAll(t, sqliteConnection);
                            }
                            break;
                        case "-l":
                            if (args.Length == 1)
                            {
                                SaveToDB.LoadAll(sqliteConnection);
                            }
                            else if (args.Length == 2)
                            {
                                try
                                {
                                    int x = Convert.ToInt32(args[1]);
                                    try
                                    {
                                        SaveToDB.Load(x, sqliteConnection);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);   
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        SaveToDB.Load(args[1], sqliteConnection);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Nem jó paramétereket adtál meg!!!");
                            }
                            break;
                        case "-r":
                            if (args.Length == 1)
                            {
                                throw new Exception("Unable to remove: no index provided");
                            }
                            else
                            {
                                try
                                {
                                    int x = Convert.ToInt32(args[1]);
                                    try
                                    {
                                        SaveToDB.RemoveElement(x, sqliteConnection);
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
                                        SaveToDB.CheckCompleted(x, sqliteConnection);
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

                            break;
                        default:
                            break;
                    }


                    sqliteConnection.Close();
                }
                else
                {
                    throw new Exception(args[0] + " nem egy létező paraméter");
                }
            }
            else
            {
                    throw new Exception("Nem adott meg paramétert");
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
        public static void Save(TODO t, SQLiteConnection sqlc)
        {
            StringBuilder sb = new StringBuilder("INSERT INTO Todos(text,createdAt) VALUES('");
            sb.Append(t.Text);
            sb.Append("','");
            sb.Append(t.CreatedAt);
            sb.Append("')");
            SQLiteCommand cmd=new SQLiteCommand("INSERT INTO Todos(text,createdAt) VALUES(@value,@date)",sqlc);
            cmd.Parameters.AddWithValue("@value",t.Text);
            cmd.Parameters.AddWithValue("@date", t.CreatedAt);
            //SQLiteCommand command = new SQLiteCommand(sb.ToString(), sqlc);
            cmd.ExecuteNonQuery();
        }
        public static void SaveAll(List<TODO> todos, SQLiteConnection sqlc)
        {
            todos.ForEach(x => Save(x,sqlc));
        }
        public static void Load(int id, SQLiteConnection sqlc)
        {
            bool exist = CheckElement(id, sqlc);
            if (exist)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Todos WHERE id=@value", sqlc))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    using (SQLiteDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            Console.WriteLine($"{r[0]}. {r[1]} {r[2]} {r[3]}");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Unable to load: index is out of bound");
            }
            
                
        }
        public static void Load(string text, SQLiteConnection sqlc)
        {
            //Console.WriteLine("Jó út");
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Todos WHERE text LIKE @value", sqlc))
            {
                cmd.Parameters.AddWithValue("@value", "%"+text+"%");
                using (SQLiteDataReader r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        while (r.Read())
                        {
                            Console.WriteLine($"{r[0]}. {r[1]} {r[2]} {r[3]}");
                        }
                    }
                    else
                    {
                        throw new Exception("No task with this text");
                    }
                }
            }
        }
        public static void LoadAll(SQLiteConnection sqlc)
        {
            string listAll = "SELECT * FROM Todos";
            List<TODO> result = new List<TODO>();
            using (SQLiteCommand command = new SQLiteCommand(listAll, sqlc))
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
                            Console.WriteLine($"{r[0]}. {r[1]} {r[2]} {r[3]}");
                        }
                    }
                }
            }
        }
        public static bool CheckElement(int id, SQLiteConnection sqlc)
        {
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * from Todos WHERE id=@value", sqlc))
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
        public static void RemoveElement(int id, SQLiteConnection sqlc)
        {
            bool exists = CheckElement(id, sqlc);
            if (exists)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Todos WHERE id=@value", sqlc))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    SQLiteDataReader r = cmd.ExecuteReader();   
                }
                Console.WriteLine($"Task with id: {id}");
            }
            else
            {
                throw new Exception("Unable to remove: index is out of bound");
            }
        }
        public static void CheckCompleted(int id, SQLiteConnection sqlc)
        {
            bool exist = CheckElement(id, sqlc);
            DateTime date = DateTime.Now;
            if (exist)
            {
                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Todos SET completedAT=@date WHERE id=@value", sqlc))
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
    }
}

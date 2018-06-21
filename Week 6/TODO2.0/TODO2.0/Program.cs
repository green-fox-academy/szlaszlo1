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
                        Console.WriteLine("Database already exist, connect to database...");
                        sqliteConnection = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                        sqliteConnection.Open();
                        Console.WriteLine("Connected to database");
                    }
                    else
                    {
                        Console.WriteLine("Create database...");
                        SQLiteConnection.CreateFile(dbName);
                        Console.WriteLine("Database created");
                        Console.WriteLine("Connect to database");
                        sqliteConnection = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                        sqliteConnection.Open();
                        Console.WriteLine("Connected to database");
                    }
                    string createTable = @"CREATE TABLE IF NOT EXIST Todos(
                                   id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                   text NVARCHAR(2048) NULL)";
                    SQLiteCommand command = new SQLiteCommand(createTable, sqliteConnection);
                    command.ExecuteNonQuery();
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
            Console.ReadKey();
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

        public TODO(string text, DateTime createdat)
        {
            this.id = TODO.id_incr;
            TODO.id_incr += 1;
            this.text = text;
            createdat = DateTime.Now;
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


        }
        public static void SaveAll(List<TODO> todos)
        {

        }
        public static void Load(int id)
        {

        }
        public static void Load(string text)
        {
        }
        public static void LoadAll()
        {


        }
    }
}

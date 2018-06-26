using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Models
{
    public class BankAccount
    {
        public static int _id = 0;
        public static string[] kings = new string[] { "Simba", "Mufasa", "Zordon" };
        public int ID { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string AnimalType { get; set; }
        public string Currency { get; set; }
        public bool King { get; set; }

        public BankAccount(string name,double balance,string animaltype, string currency="Zebra")
        {
            ID = _id++;
            Name = name;
            Balance =balance;
            AnimalType = animaltype;
            Currency = currency;
            if (kings.Contains(name))
            {
                King = true;
            }
            else
            {
                King = false;
            }
        }
    }
}

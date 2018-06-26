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
        public bool GoodGuy { get; set; }

        public BankAccount(string name,double balance,string animaltype, string currency="Zebra")
        {
            ID = _id++;
            Name = name;
            Balance =balance;
            AnimalType = animaltype;
            Currency = currency;
            GoodGuy = (name.Equals("Zordon")) ? false : true;
            King=kings.Contains(name) ? true : false;
   
        }
        public BankAccount()
        {
            ID = _id++;
            Currency = "Zebra";
        }
        public void GetMoney(int id)
        {
            if (King)
            {
                Balance += 100;
            }
            else
            {
                Balance += 10;
            }

        }
    }
}

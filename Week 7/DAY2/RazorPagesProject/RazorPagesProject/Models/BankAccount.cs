using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesProject.Models
{
    public class BankAccount
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string AnimalType { get; set; }
        public string Currency { get; set; }

        public BankAccount(string name,double balance,string animaltype, string currency="Zebra")
        {
            Name = name;
            Balance =balance;
            AnimalType = animaltype;
            Currency = currency;
        }
    }
}

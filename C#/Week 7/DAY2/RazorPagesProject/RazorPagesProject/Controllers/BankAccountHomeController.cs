﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorPagesProject.Models;

namespace RazorPagesProject.Controllers
{
    //[Route("BankAccountHome")]
    public class BankAccountHomeController : Controller
    {
        //public static List<BankAccount> bal;
        public static List<BankAccount> bal = new List<BankAccount>
            {
                new BankAccount("Zazu",1000,"Bird"),
                new BankAccount("Timon",200,"Meerkat"),
                new BankAccount("Pumba",100,"Warthod"),
                new BankAccount("Zordon",4000,"Lion"),
                new BankAccount("Mufasa",10000,"Lion")
            };
    public IActionResult Index()
        {
            return View();
        }

        //[Route("Simba")]
        public IActionResult Simba()
        {
            BankAccount ba = new BankAccount("Simba", 2000, "Animal.Lion");
            return View(ba);
        }

        public IActionResult Animals()
        {

            return View(bal);
        }

        [HttpPost]
        public IActionResult AddMoney(int id)
        {
            bal.ElementAt(id).GetMoney(id);
            return RedirectToAction("Animals");
        }
        public IActionResult AddBankAccount(BankAccount ba)
        {
            bal.Add(ba);
            return RedirectToAction("Animals");
        }
    }
}
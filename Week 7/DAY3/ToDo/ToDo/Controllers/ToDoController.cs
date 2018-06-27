using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Services;
using ToDo.Models;
using Newtonsoft.Json;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        IToDoManipulate todoapp;
        public ToDoController(IToDoManipulate todos)
        {
            todoapp = todos;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(todoapp.GetToDos());
        }
        [HttpPost("AddNewElement")]
        public IActionResult AddNewElement(Models.ToDo td)
        {

            todoapp.AddToDo(td);
            return RedirectToAction("Index");
        }

        [HttpPost("CheckElement")]
        public IActionResult CheckElement(int id)
        {
            todoapp.CheckToDo(id);
            return RedirectToAction("Index");
        }

        [HttpPost("RemoveElement")]
        public IActionResult RemoveElement(int id)
        {
            todoapp.DeleteToDo(id);
            return RedirectToAction("Index");
        }

        [HttpPost("SetUrgent")]
        public IActionResult SetUrgent(int id)
        {
            todoapp.UrgentToDo(id);
            return RedirectToAction("Index");
        }

        [HttpPost("SaveAll")]
        public IActionResult SaveAll()
        {
            todoapp.SaveAll();
            return RedirectToAction("Index");
        }

        [HttpPost("LoadAll")]
        public IActionResult LoadAll()
        {

            todoapp.LoadAll();
            return RedirectToAction("Index");
        }
    }
}
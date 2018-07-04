using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Repositories;
using TodoAppVol3.Models;

namespace TodoApp.Controllers
{
    [Route("/todo")]
    public class TodoController : Controller
    {
        ITodoRepository todorep;
        public TodoController(ITodoRepository todorep)
        {
            this.todorep = todorep;
        }


        [Route("")]
        [Route("list")]
        public IActionResult List()
        {
            return View(todorep.ListAll());
        }

        [HttpGet("/addnew")]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost("/addnew")]
        public IActionResult AddNew(Todo t)
        {
            todorep.AddNew(t);
            return RedirectToAction("List");
        }

        [HttpGet("/{id}/delete")]
        public IActionResult Delete(long id)
        {
            todorep.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet("/{id}/edit")]
        public IActionResult Edit(long id)
        {
            return View(todorep.Edit(id));
        }

        [HttpPost("/{id}/edit")]
        public IActionResult Update(Todo t)
        {
            todorep.Update(t);
            return RedirectToAction("List");
        }
    }
}
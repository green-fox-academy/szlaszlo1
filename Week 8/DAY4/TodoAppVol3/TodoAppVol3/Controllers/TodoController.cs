using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Repositories;
using TodoAppVol3.Models;
using TodoAppVol3.Repositories;

namespace TodoApp.Controllers
{
    [Route("/todo")]
    public class TodoController : Controller
    {
        TodoRepository todorep;
        AssigneeRepository assigneerep;
        public TodoController(TodoRepository todorep,AssigneeRepository assigneerep)
        {
            this.todorep = todorep;
            this.assigneerep = assigneerep;
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
            return View(todorep.GetElement(id));
        }

        [HttpPost("/{id}/edit")]
        public IActionResult Update(Todo t)
        {
            todorep.Update(t);
            return RedirectToAction("List");
        }
        [HttpPost("/searchtodos")]
        public IActionResult Search(string searchedString)
        {
            return View("List", todorep.LisrSearch(searchedString));
        }

        [HttpGet("/listAssignees")]
        public IActionResult Assignees()
        {
            return View();
        }
        [HttpPost("addAssignee")]
        public IActionResult AddAssignee(Assignee a)
        {
            assigneerep.AddNew(a);
            return RedirectToAction("Assignees");
        }
        [HttpPost("/removeAssignee")]
        public IActionResult RemoveAssignee(int id)
        {
            assigneerep.Delete(id);
            return RedirectToAction("Assignees");
        }
    }
}
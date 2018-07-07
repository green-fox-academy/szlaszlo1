using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Repositories;
using TodoAppVol3.Models;
using TodoAppVol3.Repositories;
using TodoAppVol3.Services;

namespace TodoApp.Controllers
{
    [Route("/todo")]
    public class TodoController : Controller
    {
        
        ITodoApp todosrv;
        public TodoController(ITodoApp todosrv)
        {
            this.todosrv = todosrv;
        }


        [Route("")]
        [Route("list")]
        public IActionResult List()
        {
            return View(todosrv.GetTodoOfAssigneesViewModel());
        }

        [HttpGet("/addnew")]
        public IActionResult AddNew()
        {
            return View();
        }
        [HttpPost("/addnew")]
        public IActionResult AddNew(Todo t)
        {
            todosrv.AddNew(t);
            return RedirectToAction("List");
        }

        [HttpGet("/{id}/delete")]
        public IActionResult Delete(long id)
        {
            todosrv.DeleteTodo(id);
            return RedirectToAction("List");
        }

        [HttpGet("/{id}/edit")]
        public IActionResult Edit(long id)
        {
            return View(todosrv.GetViewModel(id));
        }

        [HttpPost("/{id}/edit")]
        public IActionResult Update(Todo t)
        {
            todosrv.SetConnection(t);
            return RedirectToAction("List");
        }
        [HttpPost("/searchtodos")]
        public IActionResult Search(string searchedString)
        {
            return View("List", todosrv.GetFilteredTodo(searchedString));
        }

        [HttpGet("/listAssignees")]
        public IActionResult Assignees(int? id)
        {
            if (id == null)
            {
                return View(todosrv.GetTodoOfAssigneesViewModel());
            }
            else
            {
                return View(todosrv.GetTodoOfAssigneesViewModel(Convert.ToInt32(id)));
            }
            
        }
        [HttpPost("/addAssignee")]
        public IActionResult AddAssignee(Assignee a)
        {
            todosrv.AddNew(a);
            return RedirectToAction("Assignees");
        }
        [HttpPost("/removeAssignee")]
        public IActionResult RemoveAssignee(params long[] id)
        {
            todosrv.DeleteAssignee(id);
            return RedirectToAction("Assignees");
        }
        [HttpGet("/{id}/editAssignee")]
        public IActionResult EditAssignee(int id)
        {
            return View(todosrv.GetAssignee(id));
        }
        [HttpPost("/{id}/editAssignee")]
        public IActionResult UpdateAssignee(Assignee a)
        {
            todosrv.Update(a);
            return RedirectToAction("Assignees");
        }
        [HttpGet("/test")]
        public IActionResult Test()
        {
            return View(todosrv.GetTodoOfAssigneesViewModel());
        }
        [HttpGet("/{index}/showHide")]
        public IActionResult ShowHide(int index)
        {
            return RedirectToAction("Assignees", new { id = index });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Repositories;

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
        public IActionResult List(List<Todo> todos)
        {

            return View(todos);
        }

    }
}
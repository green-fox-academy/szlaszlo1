using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Counter.Controllers
{
    [Produces("application/json")]
    [Route("api/Counter")]
    public class CounterController : Controller
    {
    }
}
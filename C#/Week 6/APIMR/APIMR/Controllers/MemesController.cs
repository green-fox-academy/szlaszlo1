using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIMR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMR.Controllers
{
    [Produces("application/json")]
    [Route("api/Memes")]
    public class MemesController : Controller
    {
        public static List<Meme> memes = new List<Meme>()
        {
            new Meme{ ID=0,Name="T", IsDank=false},
            new Meme{ ID=1,Name="B", IsDank=true}
        };

        // GET: api/Memes
        [HttpGet]
        public IActionResult GetMemes()
        {
            return Ok(memes);
        }

        //GET: api/Memes/1
        [HttpGet("{id}")]
        public IActionResult GetMeme([FromRoute] int id)
        {
            
            if (id<=memes.Count())
            {
                return Ok(memes[id]);
            }
            else
            {
                return Content("Out of index");
            }
        }

        //POST: api/Memes
        [HttpPost]
        public void POstMeme([FromBody] Meme meme)
        {
            memes.Add(meme);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICommentBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultController : Controller
    {
        //[HttpGet]
        //public IActionResult GetNameFacult()
        {
            var rng = new Random();
            return Ok(rng.ToString());
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

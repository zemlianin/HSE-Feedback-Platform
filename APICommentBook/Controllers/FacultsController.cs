using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using APICommentBook.Models;
namespace APICommentBook.Controllers
{
    public class FacultsController : Controller
    {
        [HttpGet("Get-name-Facults")]
        public List<Facult> GetNameFacults()
        {
            return connectDB.ReadDateBasePartStudy<Facult>("SELECT * FROM facults");
        }

        [HttpPost("write-facults")]
        public void SetWriteRecord([FromBody] Facult facult)
        {
            connectDB.WriteDateBase($"insert into facults(id,name) values('{facult.Id}{facult.Name}');");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

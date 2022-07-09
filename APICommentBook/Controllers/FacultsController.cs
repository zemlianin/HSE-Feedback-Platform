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
            return connectDB.ReadDateBasePartStudy<Facult>("SELECT * FROM facultComments");
        }
        [HttpGet("Get-comments-Facults")]
        public List<Comment> GetComments()
        {
            return connectDB.ReadDateBaseComment("SELECT * FROM directionComments");
        }

        [HttpPost("write-facults")]
        public void SetWriteRecord([FromBody] Facult facult)
        {
            connectDB.WriteDateBase($"insert into facults(id,name) values('{facult.Id}{facult.Name}');");
        }

        [HttpPost("write-comment-facults")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            connectDB.WriteDateBase($"insert into facultComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

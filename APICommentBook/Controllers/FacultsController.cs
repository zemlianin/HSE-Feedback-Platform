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
        [HttpGet("Get-comments-Facults")]
        public List<Comment> GetComments()
        {
            return connectDB.ReadDateBaseComment("SELECT * FROM facultComments");
        }

        [HttpPost("write-facults")]
        public void SetWriteRecord([FromBody] Facult facult)
        {
            connectDB.RequestDateBase($"insert into facults(id,name) values('{facult.Id}{facult.Name}');");
        }

        [HttpPost("write-comment-facults")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            connectDB.RequestDateBase($"insert into facultComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }

        [HttpPost("delete-comment-facults")]
        public void DeleteComment([FromBody] Comment comment)
        {
            connectDB.RequestDateBase($"DELETE FROM facultComments WHERE id = {comment.Id}; ");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

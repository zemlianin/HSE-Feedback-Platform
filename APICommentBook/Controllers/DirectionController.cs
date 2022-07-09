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
    public class DirectionController : Controller
    {
        [HttpGet("Get-name-Directions")]
        public List<Direction> GetNameDirections()
        {
            return connectDB.ReadDateBasePartStudy<Direction>("SELECT * FROM directions");
        }
        [HttpGet("Get-comments-Directions")]
        public List<Comment> GetComments()
        {
            return connectDB.ReadDateBaseComment("SELECT * FROM directionComments");
        }

        [HttpPost("write-directions")]
        public void SetWriteRecord([FromBody] Direction direction)
        {
            connectDB.WriteDateBase($"insert into directions(id,externalId,name) values({direction.Id},{direction.ExternalId},'{direction.Name}');");
        }
        [HttpPost("write-comment-direction")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            connectDB.WriteDateBase($"insert into directionComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

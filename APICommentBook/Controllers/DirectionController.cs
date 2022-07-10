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
            connectDB.RequestDateBase($"insert into directions(id,externalId,name) values({direction.Id},{direction.ExternalId},'{direction.Name}');");
        }
        [HttpPost("write-comment-direction")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            connectDB.RequestDateBase($"insert into directionComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }

        [HttpPost("delete-comment-direction")]
        public void DeleteComment([FromBody] Comment comment)
        {
            connectDB.RequestDateBase($"DELETE FROM directionComments WHERE id = {comment.Id}; ");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

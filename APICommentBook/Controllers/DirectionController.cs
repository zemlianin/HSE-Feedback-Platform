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

        [HttpPost("write-directions")]
        public void SetWriteRecord([FromBody] Direction direction)
        {
            connectDB.WriteDateBase($"insert into directions(id,externalId,name) values({direction.Id},{direction.ExternalId},'{direction.Name}');");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

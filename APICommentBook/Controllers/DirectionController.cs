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
        /// <summary>
        /// Вывод списка направлений.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-name-Directions")]
        public List<Direction> GetNameDirections()
        {
            return connectDB.ReadDateBasePartStudy<Direction>("SELECT * FROM directions");
        }
        /// <summary>
        /// Вывод списка комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-comments-Directions")]
        public List<Comment> GetComments()
        {
            return connectDB.ReadDateBaseComment("SELECT * FROM directionComments");
        }
        /// <summary>
        /// Метод добавления направления.
        /// </summary>
        /// <param name="direction">объект направления</param>
        [HttpPost("write-directions")]
        public void SetWriteRecord([FromBody] Direction direction)
        {
            connectDB.RequestDateBase($"insert into directions(id,externalId,name) values({direction.Id},{direction.ExternalId},'{direction.Name}');");
        }
        /// <summary>
        /// Метод добавления комментария к направлению.
        /// </summary>
        /// <param name="comment">объект комментария, который будет добавлен в бд</param>
        [HttpPost("write-comment-direction")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            connectDB.RequestDateBase($"insert into directionComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }

        /// <summary>
        /// метод удаления комментария
        /// </summary>
        /// <param name="comment">объект комментария который подлежит удалению(сравнивается только id)</param>
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

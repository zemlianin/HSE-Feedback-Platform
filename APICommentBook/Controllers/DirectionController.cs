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
            return ConnectDB.ReadDateBasePartStudy<Direction>("SELECT * FROM directions");
        }

        [HttpGet("Get-name-Directions-by-externalId")]
        public List<Direction> GetNameDirectionsById(int externalId)
        {
            return ConnectDB.ReadDateBasePartStudy<Direction>($"SELECT * FROM directions WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Вывод списка комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-comments-Directions-by-externalId")]
        public List<Comment> GetComments(int externalId)
        {
            return ConnectDB.ReadDateBaseComment($"SELECT * FROM directionComments WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Метод добавления направления.
        /// </summary>
        /// <param name="direction">объект направления</param>
        [HttpPost("write-directions")]
        public void SetWriteRecord([FromBody] Direction direction)
        {
            ConnectDB.RequestDateBase($"insert into directions(id,externalId,name) values({direction.id},{direction.externalId},'{direction.name}');");
        }
        /// <summary>
        /// Метод добавления комментария к направлению.
        /// </summary>
        /// <param name="comment">объект комментария, который будет добавлен в бд</param>
        [HttpPost("write-comment-direction")]
        public void SetWriteComment( Comment comment)
        {
            ConnectDB.RequestDateBase($"insert into directionComments values({comment.id},'{comment.name}','{comment.time}','{comment.text}',{comment.externalId});");
        }

        /// <summary>
        /// метод удаления комментария
        /// </summary>
        /// <param name="comment">объект комментария который подлежит удалению(сравнивается только id)</param>
        [HttpPost("delete-comment-direction")]
        public void DeleteComment([FromBody] Comment comment)
        {
            ConnectDB.RequestDateBase($"DELETE FROM directionComments WHERE id = {comment.id}; ");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;

namespace APICommentBook {
    public abstract class ForumPageBaseController<Model> : Controller where Model : IStudyPart, new() {

        protected abstract string tableName { get; }

        /// <summary>
        /// Вывод списка направлений.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-names")]
        public List<Model> GetNameDirections() {
            return ConnectDB.ReadDateBasePartStudy<Model>($"SELECT * FROM {tableName}");
        }

        [HttpGet("get-names-by-externalId")]
        public List<Model> GetNameDirectionsById(int externalId) {
            return ConnectDB.ReadDateBasePartStudy<Model>($"SELECT * FROM {tableName} WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Вывод списка комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-comments-by-externalId")]
        public List<Comment> GetComments(int externalId) {
            return ConnectDB.ReadDateBaseComment($"SELECT * FROM {tableName}Comments WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Метод добавления направления.
        /// </summary>
        /// <param name="direction">объект направления</param>
        [HttpPost("write")]
        public void SetWriteRecord([FromBody] Direction direction) {
            ConnectDB.RequestDateBase($"insert into {tableName}(id,externalId,name) values({direction.id},{direction.externalId},'{direction.name}');");
        }
        /// <summary>
        /// Метод добавления комментария к направлению.
        /// </summary>
        /// <param name="comment">объект комментария, который будет добавлен в бд</param>
        [HttpPost("write-comment")]
        public void SetWriteComment(Comment comment) {
            System.IO.File.WriteAllText("output.txt", $"-{comment.id}");
            ConnectDB.RequestDateBase($"insert into {tableName}Comments(name,time,info,externalId) values('{comment.name}','{comment.time}','{comment.text}',{comment.externalId});");
        }

        /// <summary>
        /// метод удаления комментария
        /// </summary>
        /// <param name="comment">объект комментария который подлежит удалению(сравнивается только id)</param>
        [HttpPost("delete-comment")]
        public void DeleteComment([FromBody] Comment comment) {
            ConnectDB.RequestDateBase($"DELETE FROM {tableName}Comments WHERE id = {comment.id}; ");
        }
        protected IActionResult Index() {
            return View();
        }
    }
}

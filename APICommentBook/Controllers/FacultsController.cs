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
        /// <summary>
        /// получение списка факультетов.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-name-Facults")]
        public List<Facult> GetNameFacults()
        {
            return ConnectDB.ReadDateBasePartStudy<Facult>("SELECT * FROM facults");
        }


        [HttpGet("Get-name-Facults-by-id")]
        public List<Facult> GetNameFacultsById(int id)
        {
            return ConnectDB.ReadDateBasePartStudy<Facult>($"SELECT * FROM facults WHERE id = {id};");
        }

        /// <summary>
        /// получение списка комментариев к факультетам
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-comments-Facults-by-externalId")]
        public List<Comment> GetComments(int externalId)
        {
            return ConnectDB.ReadDateBaseComment($"SELECT * FROM facultComments WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Метод добавления нового факультета.
        /// </summary>
        /// <param name="facult">объект факультета</param>
        [HttpPost("write-facults")]
        public void SetWriteRecord([FromBody] Facult facult)
        {
            ConnectDB.RequestDateBase($"insert into facults(id,name) values('{facult.id}{facult.name}');");
        }
        /// <summary>
        /// Метод добавления комментария к факультету.
        /// </summary>
        /// <param name="comment">объект комментария, который будет добавлен в бд</param>
        [HttpPost("write-comment-facults")]
        public void SetWriteComment( Comment comment) {
            // System.IO.File.WriteAllText("output.txt", $"-{comment.id}");
            ConnectDB.RequestDateBase($"insert into facultComments(name,time,info,externalId) values('{comment.name}','{comment.time}','{comment.text}',{comment.externalId});");
        }
        /// <summary>
        /// метод удаления комментария
        /// </summary>
        /// <param name="comment">объект комментария который подлежит удалению(сравнивается только id)</param>
        [HttpPost("delete-comment-facults")]
        public void DeleteComment([FromBody] Comment comment)
        {
            ConnectDB.RequestDateBase($"DELETE FROM facultComments WHERE id = {comment.id}; ");
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}

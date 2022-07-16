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
    public class CourseController : Controller
    {
        /// <summary>
        /// Метод получения списка курсов.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-name-Courses")]
        public List<Course> GetNameCourses()
        {
            return ConnectDB.ReadDateBasePartStudy<Course>("SELECT * FROM courses");
        }
        /// <summary>
        /// Метод получения списка комментариев к курсам.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-comments-Courses")]
        public List<Comment> GetComments()
        {
            return ConnectDB.ReadDateBaseComment($"SELECT * FROM coursesComments");
        }
        /// <summary>
        /// Метод добавления нового курса.
        /// </summary>
        /// <param name="course"></param>
        [HttpPost("write-course")]
        public void SetWriteRecord([FromBody] Course course)
        {
            ConnectDB.RequestDateBase($"insert into courses(id,externalId,name) values({course.Id},{course.ExternalId},'{course.Name}');");
        }
        /// <summary>
        /// Метод добавления комментария к курсу.
        /// </summary>
        /// <param name="comment">объект комментария, который будет добавлен в бд</param>
        [HttpPost("write-comment-course")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            ConnectDB.RequestDateBase($"insert into coursesComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }
        /// <summary>
        /// метод удаления комментария
        /// </summary>
        /// <param name="comment">объект комментария который подлежит удалению(сравнивается только id)</param>
        [HttpPost("delete-comment-course")]
        public void DeleteComment([FromBody] Comment comment)
        {
            ConnectDB.RequestDateBase($"DELETE FROM coursesComments WHERE id = {comment.Id}; ");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

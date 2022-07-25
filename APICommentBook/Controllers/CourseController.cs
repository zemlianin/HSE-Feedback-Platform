﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("Get-name-Courses-by-externalId")]
        public List<Course> GetNameCoursesById( int externalId)
        {
            return ConnectDB.ReadDateBasePartStudy<Course>($"SELECT * FROM courses WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Метод получения списка комментариев к курсам.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-comments-Courses-by-externalId")]
        public List<Comment> GetComments(int externalId)
        {
            return ConnectDB.ReadDateBaseComment($"SELECT * FROM coursesComments WHERE externalId = {externalId};");
        }
        /// <summary>
        /// Метод добавления нового курса.
        /// </summary>
        /// <param name="course"></param>
        [HttpPost("write-course")]
        public void SetWriteRecord([FromBody] Course course)
        {
            ConnectDB.RequestDateBase($"insert into courses(id,externalId,name) values({course.id},{course.externalId},'{course.name}');");
        }
        /// <summary>
        /// Метод добавления комментария к курсу.
        /// </summary>
        /// <param name="comment">объект комментария, который будет добавлен в бд</param>
        [HttpPost("write-comment-course")]
        public void SetWriteComment(Comment comment)
        {
           // System.IO.File.WriteAllText("output.txt", $"-{comment.id}");
            ConnectDB.RequestDateBase($"insert into coursesComments(name,time,info,externalId) values('{comment.name}','{comment.time}','{comment.text}',{comment.externalId});");
        }
        /// <summary>
        /// метод удаления комментария
        /// </summary>
        /// <param name="comment">объект комментария который подлежит удалению(сравнивается только id)</param>
        [HttpPost("delete-comment-course")]
        public void DeleteComment([FromBody] Comment comment)
        {
            ConnectDB.RequestDateBase($"DELETE FROM coursesComments WHERE id = {comment.id}; ");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

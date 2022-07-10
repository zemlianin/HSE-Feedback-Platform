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
        [HttpGet("Get-name-Courses")]
        public List<Course> GetNameCourses()
        {
            return connectDB.ReadDateBasePartStudy<Course>("SELECT * FROM courses");
        }
        [HttpGet("Get-comments-Courses")]
        public List<Comment> GetComments()
        {
            return connectDB.ReadDateBaseComment($"SELECT * FROM coursesComments");
        }
        [HttpPost("write-course")]
        public void SetWriteRecord([FromBody] Course course )
        {
            connectDB.RequestDateBase($"insert into courses(id,externalId,name) values({course.Id},{course.ExternalId},'{course.Name}');");
        }
        [HttpPost("write-comment-course")]
        public void SetWriteComment([FromBody] Comment comment)
        {
            connectDB.RequestDateBase($"insert into coursesComments values({comment.Id},'{comment.Name}','{comment.Time}','{comment.Text}',{comment.ExternalId});");
        }
        [HttpPost("delete-comment-course")]
        public void DeleteComment([FromBody] Comment comment )
        {
            connectDB.RequestDateBase($"DELETE FROM coursesComments WHERE id = {comment.Id}; ");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

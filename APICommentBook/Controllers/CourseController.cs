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
        [HttpGet("Get-name-Courses")]
        public List<Course> GetNameCourses()
        {
            List<Course> courses = new List<Course>();
            String connectionString = "Server=postgres;Port=5432;User Id=app;Password=app;Database=mydbname;";
            //String connectionString = "Server=localhost;Port=5432;Database=mydbname;User Id=app;Password=app;";
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                // File.AppendAllText("log", "Соединение с БД открыто\n");
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM facult", npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                if (npgSqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        courses.Add(new Course()
                        {
                            Id = int.Parse(dbDataRecord["id"].ToString()),
                            Name = dbDataRecord["namecourse"].ToString()
                        });
                }
                return courses;

            }
        }

        private Course ReadDateBaseAboutCourse(string server, string port, string user, string password, string database, string action)
        {
            List<Course> courses = new List<Course>();
            //String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1Q2w3e4r5t;Database=Courses;";
            String connectionString = $"Server={server};Port={port};User Id={user};Password={password};Database={database};";
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                // File.AppendAllText("log", "Соединение с БД открыто\n");
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(action, npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                if (npgSqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        courses.Add(new Course()
                        {
                            Id = int.Parse(dbDataRecord["id"].ToString()),
                            Name = dbDataRecord["namecourse"].ToString()
                        });
                }
                return courses[0];

            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

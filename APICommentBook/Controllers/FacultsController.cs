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
        [HttpGet("Get-name-Facults")]
        public List<Facult> GetNameFacults()
        {
            List<Facult> facults = new List<Facult>();
            String connectionString = "Server=postgres;Port=5432;User Id=app;Password=app;Database=mydbname2;";
           
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
               // File.AppendAllText("log", "Соединение с БД открыто\n");
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM facults", npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                if (npgSqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        facults.Add(new Facult()
                        {
                            Id = int.Parse(dbDataRecord["id"].ToString()),
                            Name = dbDataRecord["name"].ToString()
                        }) ;
                }
                return facults;

            }
        }

        private Facult ReadDateBaseAboutFacult(string server, string port, string user, string password, string database, string action)
        {
            List<Facult> facults = new List<Facult>();
            //String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1Q2w3e4r5t;Database=Facults;";
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
                        facults.Add(new Facult()
                        {
                            Id = int.Parse(dbDataRecord["id"].ToString()),
                            Name = dbDataRecord["namefacult"].ToString()
                        });
                }
                return facults[0];

            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

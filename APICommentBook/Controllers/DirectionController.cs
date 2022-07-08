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
            List<Direction> directions = new List<Direction>();
            String connectionString = "Server=postgres;Port=5432;User Id=app;Password=app;Database=mydbname2;";
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
                        directions.Add(new Direction()
                        {
                            Id = int.Parse(dbDataRecord["id"].ToString()),
                            Name = dbDataRecord["namedirection"].ToString()
                        });
                }
                return directions;

            }
        }

        private Direction ReadDateBaseAboutDirections(string server, string port, string user, string password, string database, string action)
        {
            List<Direction> directions = new List<Direction>();
            //String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=1Q2w3e4r5t;Database=Directions;";
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
                        directions.Add(new Direction()
                        {
                            Id = int.Parse(dbDataRecord["id"].ToString()),
                            Name = dbDataRecord["namedirection"].ToString()
                        });
                }
                return directions[0];

            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

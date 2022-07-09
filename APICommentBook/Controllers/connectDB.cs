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
    public class connectDB
    {
        internal static  List<T> ReadDateBasePartStudy<T>(string command)
            where T : IStadyPart, new()
        {
            List<T> list = new List<T>();
            String connectionString = "Server=postgres;Port=5432;User Id=app;Password=app;Database=mydbname2;";
            using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
            {
                npgSqlConnection.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(command, npgSqlConnection);
                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                if (npgSqlDataReader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        if (typeof(T) != typeof(Facult))
                        {
                            list.Add(new T()
                            {
                                Id = int.Parse(dbDataRecord["id"].ToString()),
                                Name = dbDataRecord["name"].ToString(),
                                ExternalId = int.Parse(dbDataRecord["externalId"].ToString())
                            });
                        }
                        else
                        {
                            list.Add(new T()
                            {
                                Id = int.Parse(dbDataRecord["id"].ToString()),
                                Name = dbDataRecord["name"].ToString(),
                            });
                        }
                    }
                }
                return list;
            }
        }


        internal static void WriteDateBase(string command)
            
        {
            try
            {
                String connectionString = "Server=postgres;Port=5432;User Id=app;Password=app;Database=mydbname2;";
                using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString))
                {
                    npgSqlConnection.Open();
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(command, npgSqlConnection);
                    npgSqlCommand.ExecuteNonQuery();
                }
            }
            catch(Exception)
            {
                //надо сделать логер
            }
        }
    }
}

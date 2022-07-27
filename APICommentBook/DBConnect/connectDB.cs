using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data.Common;
using System.IO;

namespace APICommentBook
{
    /// <summary>
    /// класс который содержит в себе методы работы с бд и методы подключения к бд
    /// </summary>
    public class ConnectDB
    {
        private const string ConnectionString = "Server=postgres;Port=5432;User Id=app;Password=app;Database=mydbname2;";
        static internal Logger logger = new Logger("log.txt");
        /// <summary>
        /// Чтение учебной подкгруппы(факультет курс направление)
        /// </summary>
        /// <typeparam name="T">Что это за подгруппа</typeparam>
        /// <param name="command">комманда выполняемая с бд</param>
        /// <returns></returns>
        internal static List<T> ReadDateBasePartStudy<T>(string command)
            where T : IStudyPart, new()
        {
            try
            {
               
                List<T> list = new List<T>();
                using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(ConnectionString))
                {
                    npgSqlConnection.Open();
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(command, npgSqlConnection);
                    NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                    if (npgSqlDataReader.HasRows) // ????
                    {
                        foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        {
                            if (typeof(T) != typeof(Facult))
                            {
                                list.Add(new T()
                                {
                                    id = int.Parse(dbDataRecord["id"].ToString()),
                                    name = dbDataRecord["name"].ToString(),
                                    externalId = int.Parse(dbDataRecord["externalId"].ToString())
                                });
                            }
                            else
                            {
                                list.Add(new T()
                                {
                                    id = int.Parse(dbDataRecord["id"].ToString()),
                                    name = dbDataRecord["name"].ToString(),
                                });
                            }
                        }
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                ConnectDB.logger.LogInformation(e.Message + "\n");
                return new List<T>();
            }
        }
        /// <summary>
        /// Чтение комментария из базы данных
        /// </summary>
        /// <param name="command">команда для чтения</param>
        /// <returns></returns>
        internal static List<Comment> ReadDateBaseComment(string command)
        {
            try
            {
                List<Comment> list = new List<Comment>();
                using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(ConnectionString))
                {
                    npgSqlConnection.Open();
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(command, npgSqlConnection);
                    NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
                    if (npgSqlDataReader.HasRows) // ????
                    {
                        foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                        {
                            list.Add(new Comment()
                            {
                                id = int.Parse(dbDataRecord["id"].ToString()),
                                name = dbDataRecord["name"].ToString(),
                                externalId = int.Parse(dbDataRecord["externalId"].ToString()),
                                time = dbDataRecord["time"].ToString(),
                                text = dbDataRecord["info"].ToString(),
                            });
                        }
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                ConnectDB.logger.LogInformation(e.Message + "\n");
                return new List<Comment>();
                throw;
            }
        }

        /// <summary>
        /// Метод принимающий любые команды(используется для удаление и вписания комментариев)
        /// </summary>
        /// <param name="command">команда</param>
        internal static void RequestDateBase(string command)
        {
            try
            {
                using (NpgsqlConnection npgSqlConnection = new NpgsqlConnection(ConnectionString))
                {
                    npgSqlConnection.Open();
                    NpgsqlCommand npgSqlCommand = new NpgsqlCommand(command, npgSqlConnection);
                    npgSqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                ConnectDB.logger.LogInformation(e.Message + "\n");
                File.WriteAllText("output.txt", "лажа");
            }
        }
    }
}

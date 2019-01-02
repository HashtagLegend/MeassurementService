using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MeassurementWebService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeassurementWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeassurementController : ControllerBase
    {

        private static string connectionString = "Server=tcp:custom3r.database.windows.net,1433;Initial Catalog=custom3rDB;Persist Security Info=False;User ID=hashtaglegend;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Meassurement
        [HttpGet]
        public List<Meassurement> GetMeassurements()
        {
            var meassurementList = new List<Meassurement>();
            string sql = "SELECT * FROM Meassurement";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(sql, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                double pressure = reader.GetDouble(1);
                                double humidity = reader.GetDouble(2);
                                double temperature = reader.GetDouble(3);
                                DateTime timeStamp = reader.GetDateTime(4);



                                var meassurement = new Meassurement()
                                {
                                    Id = id,
                                    Pressure = pressure,
                                    Humidity = humidity,
                                    Temperature = temperature,
                                    TimeStamp = timeStamp


                                };

                                meassurementList.Add(meassurement);
                            }
                        }
                    }
                }
            }

            return meassurementList;
        }

        // GET: api/Meassurement/5
        [HttpGet("{inputId}", Name = "GetMeassurementById")]
        public Meassurement GetMeassurementById(int inputId)
        {
            string sql = "SELECT * FROM Meassurement " + $"WHERE Id = {inputId}";

            var meassurementToFind = new Meassurement();
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(sql, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            double pressure = reader.GetDouble(1);
                            double humidity = reader.GetDouble(2);
                            double temperature = reader.GetDouble(3);
                            DateTime timeStamp = reader.GetDateTime(4);
                            
                            var meassurement = new Meassurement()
                            {
                                Id = id,
                                Pressure = pressure,
                                Humidity = humidity,
                                Temperature = temperature,
                                TimeStamp = timeStamp
                                
                            };

                            meassurementToFind = meassurement;
                        }

                    }
                }
            }

            return meassurementToFind;
        }

        // POST: api/Meassurement
        [HttpPost]
        public Meassurement PostMeassurement([FromBody] Meassurement meassurement)
        {
            string insertMeassurement = "INSERT INTO Meassurement (Pressure, Humidity, Temperature, TimeStamp) VALUES (@Pressure, @Humidity, @Temperature, @TimeStamp)";

            SqlConnection connect = new SqlConnection(connectionString);
            using (SqlCommand insertCommand = new SqlCommand(insertMeassurement, connect))
            {
                connect.Open();
                insertCommand.Parameters.AddWithValue("@Pressure", meassurement.Pressure);
                insertCommand.Parameters.AddWithValue("@Humidity", meassurement.Humidity);
                insertCommand.Parameters.AddWithValue("@Temperature", meassurement.Temperature);
                insertCommand.Parameters.AddWithValue("@TimeStamp", meassurement.TimeStamp);
                insertCommand.ExecuteNonQuery();
            }

            return meassurement;

        }

        // PUT: api/Meassurement/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string deleteMeassurement = $"DELETE FROM Meassurement WHERE Id = {id}";

            SqlConnection connect = new SqlConnection(connectionString);
            using (SqlCommand insertCommand = new SqlCommand(deleteMeassurement, connect))
            {
                connect.Open();
                insertCommand.ExecuteNonQuery();
            }

            
        }
    }
}

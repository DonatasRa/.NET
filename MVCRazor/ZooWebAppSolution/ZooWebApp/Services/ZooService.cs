using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using ZooWebApp.Models;

namespace ZooWebApp.Services
{
    public class ZooService
    {
        private readonly ILogger<ZooService> _logger;
        private SqlConnection _connection;
        public ZooService(ILogger<ZooService> logger, SqlConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public List<ZooModel> GetAll()
        {
            List<ZooModel> animals = new List<ZooModel>();

            _connection.Open();
            using var cmd = new SqlCommand("SELECT * FROM dbo.Zoo;", _connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                animals.Add(new ZooModel()
                {
                    Name = reader.GetString(0),
                    Description = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    Gender = reader.GetString(3)
                });
            }
            _connection.Close();
            return animals;
        }
    }
}

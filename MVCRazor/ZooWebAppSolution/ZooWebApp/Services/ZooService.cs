using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using ZooWebApp.Models;
using Dapper;

namespace ZooWebApp.Services
{
    public class ZooService
    {
        private SqlConnection _connection;
        public ZooService(ILogger<ZooService> logger, SqlConnection connection)
        {
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

        public void AddAnimal(ZooModel animal)
        {
            string query = 
                $"INSERT INTO dbo.Zoo (Name, Description, Age, Gender)" +
                $" VALUES ('{animal.Name}','{animal.Description}','{animal.Age}','{animal.Gender}')";
            _connection.Query<ZooModel>(query);
        }

        public void DeleteAnimal(ZooModel animal)
        {
            string query = $"DELETE FROM dbo.Zoo WHERE Id={animal.Id}";
            _connection.Query<ZooModel>(query);
        }
        public void UpdateAnimal(ZooModel animal)
        {
            string query =
                $"UPDATE dbo.Zoo SET Name='{animal.Name}', Description='{animal.Description}', Age={animal.Age}, Gender='{animal.Gender}' WHERE Id={animal.Id}";
            _connection.Query<ZooModel>(query);
        }
    }
}

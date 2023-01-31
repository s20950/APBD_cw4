
using System.Collections.Generic;
using System.Data.SqlClient;
using Cw4.Models;
using Microsoft.Extensions.Configuration;

namespace Cw4.Services
{
    internal class SqlServerDatabaseService : IDatabaseService
    {
        private IConfiguration _configuration;

        public SqlServerDatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public int CreateAnimal(Animal newAnimal)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "INSERT INTO Animal VALUES (@name, @description, @category, @area)";
                com.Parameters.AddWithValue("@name", newAnimal.Name);
                com.Parameters.AddWithValue("@description", newAnimal.Description);
                com.Parameters.AddWithValue("@category", newAnimal.Category);
                com.Parameters.AddWithValue("@area", newAnimal.Area);
                con.Open();
                return com.ExecuteNonQuery();
            }
        }

        public int DeleteAnimal(int idAnimal)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "DELETE FROM Animal WHERE IdAnimal=@idAnimal";
                com.Parameters.AddWithValue("@idAnimal", idAnimal);
                con.Open();
                return com.ExecuteNonQuery();
            }
        }

        public Animal GetAnimal(int idAnimal)
        {
            Animal animal;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animal WHERE IdAnimal=@idAnimal";
                com.Parameters.AddWithValue("@idAnimal", idAnimal);
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                animal = new()
                {
                    IdAnimal = (int)dr["IdAnimal"],
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                };
            }
            return animal;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            var res = new List<Animal>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "SELECT * FROM Animal";
                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    res.Add(
                        new Animal
                        {
                            IdAnimal = (int)dr["IdAnimal"],
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            Category = dr["Category"].ToString(),
                            Area = dr["Area"].ToString()
                        }
                        );
                }
            }
            return res;
        }

        public int UpdateAnimal(int idAnimal, Animal updatedAnimal)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "UPDATE Animal SET Name=@name,Description=@description,Category=@category,Area=@area WHERE IdAnimal=@id";
                com.Parameters.AddWithValue("@id", updatedAnimal.IdAnimal);
                com.Parameters.AddWithValue("@name", updatedAnimal.Name);
                com.Parameters.AddWithValue("@description", updatedAnimal.Description);
                com.Parameters.AddWithValue("@category", updatedAnimal.Category);
                com.Parameters.AddWithValue("@area", updatedAnimal.Area);
                con.Open();
                return com.ExecuteNonQuery();
            }
        }
    }
}
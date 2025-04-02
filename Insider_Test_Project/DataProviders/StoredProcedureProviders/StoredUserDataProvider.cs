using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Insiders_Test_Project.DataProviders.Interfaces;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredUserDataProvider : IUserDataProvider
    {
        private readonly string _connectionString;
        public bool InsertUser(User user)
        {
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public User GetUserById(Guid Id)
        {
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public ICollection<User> GetAllUsers()
        {
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
        public bool UpdateUser(Guid Id, User newUser)
        {
            string query = "";
            string storedProcedureName = "";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                throw new NotImplementedException();
            }
        }
        public bool DeleteUser(Guid Id)
        {
            string query = "";
            string storedProcedureName = "";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}

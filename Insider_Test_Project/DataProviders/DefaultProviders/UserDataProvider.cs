using Insiders_Test_Project.DataProviders.Interfaces;
using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Insiders_Test_Project.DataProviders.DefaultProviders
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly string _connectionString;
        public bool InsertUser(User user)
        {
            string query = "INSERT INTO Users (Id, Name, Email, PasswordHash) VALUES (@Id, @Name, @Email, @PasswordHash)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) throw new InvalidOperationException("Failed to insert the user to database");
                    return true;
                }
            }
        }
        public User GetUserById(Guid Id)
        {
            string query = "SELECT Id, Name, Email, PasswordHash FROM Users WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                PasswordHash = reader.GetString(3)
                            };
                            return user;
                        }
                        else
                        {
                            throw new KeyNotFoundException($"User with ID {Id} is not found.");
                        }
                    }
                }
            }
        }
        public ICollection<User> GetAllUsers()
        {
            string query = "SELECT Id, Name, Email, PasswordHash FROM Users";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var users = new List<User>();
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                PasswordHash = reader.GetString(3)
                            };
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }
        public bool UpdateUser(Guid Id, User newUser)
        {
            string query = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", Id);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Users");
                    if (ds.Tables["Users"].Rows.Count == 0) throw new KeyNotFoundException($"User with ID {Id} is not found.");
                    DataRow row = ds.Tables["Users"].Rows[0];
                    row["Name"] = newUser.Name;
                    row["Email"] = newUser.Email;
                    row["PasswordHash"] = newUser.PasswordHash;
                    var builder = new SqlCommandBuilder(adapter);
                    int affected = adapter.Update(ds, "Users");
                    if (affected == 0) throw new InvalidOperationException("Failed to update user.");
                    return true;
                }
            }
        }
        public bool DeleteUser(Guid Id)
        {
            string query = "DELETE FROM Users WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    int affectedRows = command.ExecuteNonQuery();
                    if (affectedRows == 0) throw new InvalidOperationException("Failed to delete the user.");
                    return true;
                }
            }
        }
    }
}

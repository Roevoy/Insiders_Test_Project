using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Insiders_Test_Project.DataProviders.Interfaces;
using WinFormProject1;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredUserDataProvider : IUserDataProvider
    {
        private readonly string _connectionString = Program.ConnectionString;
        public bool InsertUser(User user)
        {
            string storedProcedureName = "InsertUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = user.Id;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
                    command.Parameters["@Name"].Value = user.Name;
                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                    command.Parameters["@Email"].Value = user.Email;
                    command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar));
                    command.Parameters["@PasswordHash"].Value = user.PasswordHash;

                    SqlParameter response = new SqlParameter("@OutputParameter", SqlDbType.Int);
                    response.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(response);

                    command.ExecuteNonQuery();

                    int result = (int)command.Parameters["@OutputParameter"].Value;
                    return (result == 0);
                }
            }
        }
        public User GetUserById(Guid Id)
        {
            string storedProcedureName = "GetUserById";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value =Id;
                    using SqlDataReader reader = command.ExecuteReader();
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
            
            string storedProcedureName = "GetAllUsers";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
            
            string storedProcedureName = "UpdateUser";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
                    command.Parameters["@Name"].Value = newUser.Name;
                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
                    command.Parameters["@Email"].Value = newUser.Email;
                    command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.NVarChar));
                    command.Parameters["@PasswordHash"].Value = newUser.PasswordHash;

                    SqlParameter outputParam = new SqlParameter("@OutputParameter", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(outputParam);

                    command.ExecuteNonQuery();

                    int result = (int)command.Parameters["@OutputParameter"].Value;
                    return (result == 0);
                }
            }
        }
        public bool DeleteUser(Guid Id)
        {
            string storedProcedureName = "DeleteUser";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;

                    SqlParameter outputParam = new SqlParameter("@OutputParameter", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(outputParam);

                    command.ExecuteNonQuery();

                    int result = (int)command.Parameters["@OutputParameter"].Value;
                    return (result == 0);
                }
            }
        }
    }
}

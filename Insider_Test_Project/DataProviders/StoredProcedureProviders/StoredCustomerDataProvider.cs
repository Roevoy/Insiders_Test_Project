using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Insiders_Test_Project.DataProviders.Interfaces;
using System.Data;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredCustomerDataProvider : ICustomerDataProvider
    {
        private readonly string _connectionString = "Server=;Database=;userId=;Password=;";
        private readonly IUserDataProvider _userDataProvider;
        public bool InsertCustomer(Customer customer)
        {
            _userDataProvider.GetUserById(customer.UserId);
            
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = customer.Id;
                    command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier));
                    command.Parameters["@UserId"].Value = customer.UserId;

                    SqlParameter outputParameter = new SqlParameter("@OutputParameter", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(outputParameter);

                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@OutputParameter"].Value == 0;
                }
            }
        }
        public Customer GetCustomerById(Guid Id)
        {
            
            string storedProcedureName = "";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;

                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.ReturnValue;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var customer = new Customer
                            {
                                Id = reader.GetGuid(1),
                                UserId = reader.GetGuid(2)
                            };
                            return customer;
                        }
                        else throw new KeyNotFoundException($"Customer with ID {Id} is not found.");
                    }
                }
            }
        }
        public ICollection<Customer> GetAllCustomers()
        {
            
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var customers = new List<Customer>();
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                Id = reader.GetGuid(1),
                                UserId = reader.GetGuid(2)
                            };
                            customers.Add(customer);
                        }
                        return customers;
                    }
                }
            }
        }
        public bool DeleteCustomer(Guid Id)
        {
            
            string storedProcedureName = "";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                    command.Parameters["@Id"].Value = Id;
                    command.Parameters.Add(new SqlParameter("@OutputParameter", SqlDbType.Int));
                    command.Parameters["@OutputParameter"].Direction = ParameterDirection.ReturnValue;
                    command.ExecuteNonQuery();
                    return (int)command.Parameters["@OutputParameter"].Value == 0;
                }
            }
        }
    }
}

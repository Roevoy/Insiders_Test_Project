using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Insiders_Test_Project.DataProviders.Interfaces;
using System.Data;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredCustomerDataProvider : ICustomerDataProvider
    {
        private readonly string _connectionString = "Server=;Database=;customer Id=;Password=;";
        private readonly IUserDataProvider _userDataProvider;
        public bool InsertCustomer(Customer customer)
        {
            _userDataProvider.GetUserById(customer.UserId);
            
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
        public Customer GetCustomerById(Guid Id)
        {
            
            string storedProcedureName = "";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    throw new NotImplementedException();
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
                    throw new NotImplementedException();
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
                    throw new NotImplementedException();
                }
            }
        }
    }
}

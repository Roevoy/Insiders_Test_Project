using Insiders_Test_Project.Models;
using Microsoft.Data.SqlClient;
using Insiders_Test_Project.DataProviders.Interfaces;

namespace Insiders_Test_Project.DataProviders.StoredProcedureProviders
{
    public class StoredCustomerDataProvider : ICustomerDataProvider
    {
        private readonly string _connectionString = "Server=;Database=;customer Id=;Password=;";
        private readonly IUserDataProvider _userDataProvider;
        public bool InsertCustomer(Customer customer)
        {
            _userDataProvider.GetUserById(customer.UserId);
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
        public Customer GetCustomerById(Guid Id)
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
        public ICollection<Customer> GetAllCustomers()
        {
            string query = "";
            string storedProcedureName = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }
        public bool DeleteCustomer(Guid Id)
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
